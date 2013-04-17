using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PromoveoAddin.UserManagement
{
    public partial class PublishingPlatformRole : Form
    {
        private int GetConfigurationID()
        {
            return Convert.ToInt32(this.cmbConfiguration.SelectedItem);
        }
        
        public PublishingPlatformRole()
        {
            InitializeComponent();
        }

        private void PublishingPlatformRole_Load(object sender, EventArgs e)
        {
            ConfigurationService.ConfigurationClient configurationClient = new ConfigurationService.ConfigurationClient();
            this.configurationBindingSource.DataSource = configurationClient.GetConfigurations();

            PublishingPlatformRoleService.PublishingPlatformRoleClient publishingPlatformRoleClient = new PublishingPlatformRoleService.PublishingPlatformRoleClient();
            this.roleBindingSource.DataSource = publishingPlatformRoleClient.GetRoles();
            this.roleBindingSource.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());

            this.RoleCBBindingSource.DataSource = publishingPlatformRoleClient.GetRoles();
            this.RoleCBBindingSource.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());

            //set up list boxes for users
            ColumnHeader header = lsvAvailableUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAvailableUsers.Columns.Add("Name");
            lsvAvailableUsers.Columns.Add("Shortname");
            header = lsvAssignedUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAssignedUsers.Columns.Add("Name");
            lsvAssignedUsers.Columns.Add("Shortname");
        }

        private void PopulateListView(ListView listView, IList<UserRoleService.User> users)
        {
            listView.Items.Clear();
            foreach (UserRoleService.User user in users)
            {
                ListViewItem item = listView.Items.Add(user.Id.ToString());
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Shortname);
            }

        }

        private void dgdRoles_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
                dgdRoles["FK_Configuration", e.RowIndex].Value = GetConfigurationID();            
        }

        private void tbcSettings_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbcSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tbcSettings.SelectedIndex == 1)
            {
                CheckItems();
            }
            if (this.tbcSettings.SelectedIndex == 2)
            {
                int roleID = 0;
                if (this.cmbSelectRole.SelectedValue != null)
                {
                    roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
                }
                UserRoleService.UserRoleClient UserRoleClient = new UserRoleService.UserRoleClient();
                PopulateListView(this.lsvAssignedUsers, UserRoleClient.GetAssignedUsers(roleID));
                PopulateListView(this.lsvAvailableUsers, UserRoleClient.GetUnassignedUsers(roleID));
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ModelToPublishingPlatformRoleAssignmentService.ModelToPublishingPlatformRoleAssignmentClient modelRoleClient = new ModelToPublishingPlatformRoleAssignmentService.ModelToPublishingPlatformRoleAssignmentClient();

            
            for (int i = 0; i < this.chkModels.Items.Count; i++)
            {
                object item = this.chkModels.Items[i];
                modelRoleClient.PersistRoleModelAssignment(item.ToString(), Convert.ToInt32(((DataRowView)this.cbxRole.SelectedValue).Row[0]),
                    chkModels.GetItemCheckState(chkModels.Items.IndexOf(item)) == System.Windows.Forms.CheckState.Checked);
            }
        }

        private void CheckItems()
        {
            
            ModelToPublishingPlatformRoleAssignmentService.ModelToPublishingPlatformRoleAssignmentClient modelRoleClient = new ModelToPublishingPlatformRoleAssignmentService.ModelToPublishingPlatformRoleAssignmentClient();
            ProcessModelService.ProcessModelClient processModelClient = new ProcessModelService.ProcessModelClient();
            this.chkModels.Items.Clear();
            foreach (ProcessModelService.ProcessModel  item in processModelClient.GetProcessModels().Where(cc => cc.FK_Configuration == GetConfigurationID()))
            {
                int newItemID = this.chkModels.Items.Add(item.ModelName);
                if (this.cbxRole.SelectedValue != null)
                {
                    if (modelRoleClient.IsChecked(item.ModelName, Convert.ToInt32(((DataRowView)this.cbxRole.SelectedValue).Row[0])))
                    {
                        chkModels.SetItemChecked(newItemID, true);
                    }
                }
            }
        }

        private void cbxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckItems();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            UserRoleService.UserRoleClient userRoleClient = new UserRoleService.UserRoleClient();

            int roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
            foreach (ListViewItem item in lsvAssignedUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                userRoleClient.RemoveUser(roleID, userID);
            }
            PopulateListView(this.lsvAssignedUsers, userRoleClient.GetAssignedUsers(roleID));
            PopulateListView(this.lsvAvailableUsers, userRoleClient.GetUnassignedUsers(roleID));
        }

        private void btnAssignSelected_Click(object sender, EventArgs e)
        {
            UserRoleService.UserRoleClient userRoleClient = new UserRoleService.UserRoleClient();
            
            int roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
            foreach (ListViewItem item in lsvAvailableUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                userRoleClient.AssignUser(roleID, userID);
            }
            PopulateListView(this.lsvAssignedUsers, userRoleClient.GetAssignedUsers(roleID));
            PopulateListView(this.lsvAvailableUsers, userRoleClient.GetUnassignedUsers(roleID));
        }

        private void cmbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RoleCBBindingSource.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
            //this.bsCbRoles.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
            CheckItems();
        }



        private void dgdRoles_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //update the table to the database
            PublishingPlatformRoleService.PublishingPlatformRoleClient roleClient = new PublishingPlatformRoleService.PublishingPlatformRoleClient();
            roleClient.UpdateRole(new PublishingPlatformRoleService.Role() { Id = Convert.ToInt32(dgdRoles[0, e.RowIndex].Value),
                Name = Convert.ToString(dgdRoles[1, e.RowIndex].Value), FK_Configuration = GetConfigurationID() });
           

        }

        private void cmbSelectRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int roleID = 0;
            if (this.cmbSelectRole.SelectedValue != null)
            {
                roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
            }
            UserRoleService.UserRoleClient userRoleClient = new UserRoleService.UserRoleClient();
            PopulateListView(this.lsvAssignedUsers, userRoleClient.GetAssignedUsers(roleID));
            PopulateListView(this.lsvAvailableUsers, userRoleClient.GetUnassignedUsers(roleID));
        }

        private void dgdRoles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter a value.", "Promoveo Addin");
        }


    }
}
