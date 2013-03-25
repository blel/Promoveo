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
            if (this.cmbConfiguration.Items.Count > 0 && this.cmbConfiguration.SelectedItem != null)
                return Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            return 0;
        }
        
        public PublishingPlatformRole()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PublishingPlatformRole_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'promoveoDataSet.Configuration' table. You can move, or remove it, as needed.
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);
            // TODO: This line of code loads data into the 'promoveoDataSet.PublishingPlatformRole' table. You can move, or remove it, as needed.
            this.publishingPlatformRoleTableAdapter.Fill(this.promoveoDataSet.PublishingPlatformRole);
            this.bsPublishingRole.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
            this.bsCbRoles.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());

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

        private void PopulateListView(ListView listView, IEnumerable<Data.PromoveoDataSet.PublishingPlatformUserRow> rows)
        {
            listView.Items.Clear();
            foreach (Data.PromoveoDataSet.PublishingPlatformUserRow row in rows)
            {
                ListViewItem item = listView.Items.Add(row.Id.ToString());
                item.SubItems.Add(row.Name);
                item.SubItems.Add(row.Shortname);
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
                UserRoleDAL userRoleDAL = new UserRoleDAL();
                PopulateListView(this.lsvAssignedUsers, userRoleDAL.GetAssignedUsers(roleID));
                PopulateListView(this.lsvAvailableUsers, userRoleDAL.GetUnassignedUsers(roleID));
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RoleModelDAL rmDal = new RoleModelDAL();
            for (int i = 0; i < this.chkModels.Items.Count; i++)
            {
                object item = this.chkModels.Items[i];
                rmDal.PersistRoleModelAssignment(item.ToString(), Convert.ToInt32(((DataRowView)this.cbxRole.SelectedValue).Row[0]),
                    chkModels.GetItemCheckState(chkModels.Items.IndexOf(item)) == System.Windows.Forms.CheckState.Checked);
            }
        }

        private void CheckItems()
        {
            ProcessModelDAL pmDal = new ProcessModelDAL();
            RoleModelDAL rmDal = new RoleModelDAL();
            this.chkModels.Items.Clear();
            foreach (DataRow item in pmDal.GetProcessModels().Rows.Cast<Data.PromoveoDataSet.ProcessModelRow>().Where(cc =>cc.FK_Configuration==GetConfigurationID()))
            {
                int newItemID = this.chkModels.Items.Add(item["ProcessModel"]);
                if (this.cbxRole.SelectedValue != null)
                {
                    if (rmDal.IsChecked(item["ProcessModel"].ToString(), Convert.ToInt32(((DataRowView)this.cbxRole.SelectedValue).Row[0])))
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
            UserRoleDAL userRoleDAL = new UserRoleDAL();
            int roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
            foreach (ListViewItem item in lsvAssignedUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                userRoleDAL.RemoveUser(roleID, userID);
            }
            PopulateListView(this.lsvAssignedUsers, userRoleDAL.GetAssignedUsers(roleID));
            PopulateListView(this.lsvAvailableUsers, userRoleDAL.GetUnassignedUsers(roleID));
        }

        private void btnAssignSelected_Click(object sender, EventArgs e)
        {
            UserRoleDAL userRoleDAL = new UserRoleDAL();
            int roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
            foreach (ListViewItem item in lsvAvailableUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                userRoleDAL.AssignUser(roleID, userID);
            }
            PopulateListView(this.lsvAssignedUsers, userRoleDAL.GetAssignedUsers(roleID));
            PopulateListView(this.lsvAvailableUsers, userRoleDAL.GetUnassignedUsers(roleID));
        }

        private void cmbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bsPublishingRole.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
            this.bsCbRoles.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
            CheckItems();
        }



        private void dgdRoles_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //update the table to the database
            publishingPlatformRoleTableAdapter.Update(promoveoDataSet.PublishingPlatformRole);

        }

        private void dgdRoles_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void cmbSelectRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int roleID = 0;
            if (this.cmbSelectRole.SelectedValue != null)
            {
                roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
            }
            UserRoleDAL userRoleDAL = new UserRoleDAL();
            PopulateListView(this.lsvAssignedUsers, userRoleDAL.GetAssignedUsers(roleID));
            PopulateListView(this.lsvAvailableUsers, userRoleDAL.GetUnassignedUsers(roleID));
        }


    }
}
