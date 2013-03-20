using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PromoveoAddin.UserManagement
{
    public partial class frmModelRoles : Form
    {
        BindingSource _bsModelUserRoles;
        
        public frmModelRoles()
        {
            InitializeComponent();
        }

        private void frmModelRoles_Load(object sender, EventArgs e)
        {
            //Configuration Combobox Datasource
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);
            
            //
            if (this.cmbConfiguration.Items.Count > 0)
            {
                //DataGridView
                _bsModelUserRoles = new BindingSource();
                _bsModelUserRoles.DataSource = new ModelUserRolesDAL().GetModelUserRoles(Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]));
                this.dgvModelUserRoles.DataSource = _bsModelUserRoles;
                //dont show technical keys (but keep them in the table)
                dgvModelUserRoles.Columns["Id"].Visible = false ;
                dgvModelUserRoles.Columns["FK_Configuration"].Visible=false;
            }

            ColumnHeader header = lsvAvailableUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAvailableUsers.Columns.Add("Name");
            lsvAvailableUsers.Columns.Add("Shortname");
            header = lsvAssignedUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAssignedUsers.Columns.Add("Name");
            lsvAssignedUsers.Columns.Add("Shortname");
        }

        private void dgvModelUserRoles_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //update the foreign key cell
            dgvModelUserRoles["FK_Configuration", e.RowIndex].Value = GetConfigurationID();
        }




        private void dgvModelUserRoles_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //update the table to the database
            ModelUserRolesDAL modelUserDAL = new ModelUserRolesDAL();
            DataView bsDataView = (DataView)_bsModelUserRoles.List;
            Data.PromoveoDataSet.ModelUserGroupDataTable bsmodelUserGroupTable = (Data.PromoveoDataSet.ModelUserGroupDataTable)bsDataView.Table;   
            modelUserDAL.Update(bsmodelUserGroupTable);
        }

        private void tbcModelUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcModelUsers.SelectedIndex == 1)
            {
                if (GetConfigurationID() > 0)
                {
                    ModelUserRolesDAL modelUserRoleDAL = new ModelUserRolesDAL();
                    
                    this.cmbModelUserRole.DataSource = modelUserRoleDAL.GetModelUserRoles(GetConfigurationID());
                    this.cmbModelUserRole.ValueMember = "Id";
                    this.cmbModelUserRole.DisplayMember = "Name";

                    PopulateListView(lsvAssignedUsers, modelUserRoleDAL.GetAssignedUser(GetRoleID(), GetConfigurationID()));
                    PopulateListView(lsvAvailableUsers, modelUserRoleDAL.GetAvailableUser(GetRoleID(), GetConfigurationID()));
                }
            }
        }

        private void PopulateListView(ListView listView, Data.PromoveoDataSet.PublishingPlatformUserDataTable rows)
        {
            listView.Items.Clear();
            foreach (Data.PromoveoDataSet.PublishingPlatformUserRow row in rows.Rows)
            {
                ListViewItem item = listView.Items.Add(row.Id.ToString());
                item.SubItems.Add(row.Name);
                item.SubItems.Add(row.Shortname);
            }


        }

        private void btnAssignSelected_Click(object sender, EventArgs e)
        {
            ModelUserRolesDAL modelUserRolesDAL = new ModelUserRolesDAL();
            foreach (ListViewItem item in lsvAvailableUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                modelUserRolesDAL.AssignUser(GetConfigurationID(), GetRoleID(), userID);
            }
            PopulateListView(lsvAssignedUsers, modelUserRolesDAL.GetAssignedUser(GetRoleID(), GetConfigurationID()));
            PopulateListView(lsvAvailableUsers, modelUserRolesDAL.GetAvailableUser(GetRoleID(), GetConfigurationID()));
        }


        private int GetConfigurationID()
        {
            if (this.cmbConfiguration.Items.Count > 0 && this.cmbConfiguration.SelectedItem != null)
                return Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            return 0;
        }

        private int GetRoleID()
        {
            if (this.cmbModelUserRole.Items.Count > 0 && this.cmbModelUserRole.SelectedItem != null)
                return Convert.ToInt32(((DataRowView)this.cmbModelUserRole.SelectedItem).Row[0]);
            return 0;
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            ModelUserRolesDAL modelUserRolesDAL = new ModelUserRolesDAL();
            foreach (ListViewItem item in lsvAssignedUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                modelUserRolesDAL.RemoveUser(GetConfigurationID(), GetRoleID(), userID);
            }
            PopulateListView(lsvAssignedUsers, modelUserRolesDAL.GetAssignedUser(GetRoleID(), GetConfigurationID()));
            PopulateListView(lsvAvailableUsers, modelUserRolesDAL.GetAvailableUser(GetRoleID(), GetConfigurationID()));
        }

        private void cmbModelUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelUserRolesDAL modelUserRoleDAL = new ModelUserRolesDAL();
            PopulateListView(lsvAssignedUsers, modelUserRoleDAL.GetAssignedUser(GetRoleID(), GetConfigurationID()));
            PopulateListView(lsvAvailableUsers, modelUserRoleDAL.GetAvailableUser(GetRoleID(), GetConfigurationID()));
        }

    }
}
