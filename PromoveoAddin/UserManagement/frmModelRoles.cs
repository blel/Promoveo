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
            //setup list boxes
            ColumnHeader header = lsvAvailableUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAvailableUsers.Columns.Add("Name");
            lsvAvailableUsers.Columns.Add("Shortname");
            header = lsvAssignedUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAssignedUsers.Columns.Add("Name");
            lsvAssignedUsers.Columns.Add("Shortname");
            //setup role combobox
            this.cmbModelUserRole.ValueMember = "Id";
            this.cmbModelUserRole.DisplayMember = "Name";
        }

        /// <summary>
        /// Here, the datagridview is setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModelRoles_Load(object sender, EventArgs e)
        {
            //Configuration Combobox Datasource
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);

            //
            if (this.cmbConfiguration.Items.Count > 0)
            {
                //Fill DataGridView. Instead of using the dal, a simple filter could be applied...
                _bsModelUserRoles = new BindingSource();
                _bsModelUserRoles.DataSource = new ModelUserRolesDAL().GetModelUserRoles(Convert.ToInt32(this.cmbConfiguration.SelectedValue));
                this.dgvModelUserRoles.DataSource = _bsModelUserRoles;
                //dont show technical keys (but keep them in the table)
                dgvModelUserRoles.Columns["Id"].Visible = false ;
                dgvModelUserRoles.Columns["FK_Configuration"].Visible=false;
            }

        }

        private void dgvModelUserRoles_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //make sure the foreign key is set when the row is left.
            //the row leave event occurs before the validating event, so this is the right place to do last changes..
            dgvModelUserRoles["FK_Configuration", e.RowIndex].Value = this.cmbConfiguration.SelectedValue;
        }

        private void dgvModelUserRoles_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //row is validated, so do the update to the database.
            ModelUserRolesDAL modelUserDAL = new ModelUserRolesDAL();
            DataView bsDataView = (DataView)_bsModelUserRoles.List;
            Data.PromoveoDataSet.ModelUserGroupDataTable bsmodelUserGroupTable = (Data.PromoveoDataSet.ModelUserGroupDataTable)bsDataView.Table;   
            modelUserDAL.Update(bsmodelUserGroupTable);
        }

        /// <summary>
        /// refresh all data in the role assingment
        /// </summary>
        private void RefreshRoleAssignmentTab()
        {
            ModelUserRolesDAL modelUserRoleDAL = new ModelUserRolesDAL();
            this.cmbModelUserRole.DataSource = modelUserRoleDAL.GetModelUserRoles(Convert.ToInt32(this.cmbConfiguration.SelectedValue));
            PopulateListView(lsvAssignedUsers, modelUserRoleDAL.GetAssignedUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
            PopulateListView(lsvAvailableUsers, modelUserRoleDAL.GetAvailableUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
        }

        /// <summary>
        /// Populate the list view accordingly
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="rows"></param>
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

        /// <summary>
        /// User adds selected entries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAssignSelected_Click(object sender, EventArgs e)
        {
            ModelUserRolesDAL modelUserRolesDAL = new ModelUserRolesDAL();
            foreach (ListViewItem item in lsvAvailableUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                modelUserRolesDAL.AssignUser(Convert.ToInt32(this.cmbConfiguration.SelectedValue), Convert.ToInt32(this.cmbModelUserRole.SelectedValue), userID);
            }
            PopulateListView(lsvAssignedUsers, modelUserRolesDAL.GetAssignedUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
            PopulateListView(lsvAvailableUsers, modelUserRolesDAL.GetAvailableUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
        }


        /// <summary>
        /// User removes selected entries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            ModelUserRolesDAL modelUserRolesDAL = new ModelUserRolesDAL();
            foreach (ListViewItem item in lsvAssignedUsers.SelectedItems)
            {
                int userID = Convert.ToInt32(item.Text);
                modelUserRolesDAL.RemoveUser(Convert.ToInt32(this.cmbConfiguration.SelectedValue), Convert.ToInt32(this.cmbModelUserRole.SelectedValue), userID);
            }
            PopulateListView(lsvAssignedUsers, modelUserRolesDAL.GetAssignedUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
            PopulateListView(lsvAvailableUsers, modelUserRolesDAL.GetAvailableUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
        }

        /// <summary>
        /// if the role is changed, make sure the list views are updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbModelUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelUserRolesDAL modelUserRoleDAL = new ModelUserRolesDAL();
            PopulateListView(lsvAssignedUsers, modelUserRoleDAL.GetAssignedUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
            PopulateListView(lsvAvailableUsers, modelUserRoleDAL.GetAvailableUser(Convert.ToInt32(this.cmbModelUserRole.SelectedValue), Convert.ToInt32(this.cmbConfiguration.SelectedValue)));
        }

        /// <summary>
        /// If the configuration cb is changed, make sure that the data is refreshed in the tabs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bsModelUserRoles.DataSource = new ModelUserRolesDAL().GetModelUserRoles(Convert.ToInt32(this.cmbConfiguration.SelectedValue));
            RefreshRoleAssignmentTab();
        }

        /// <summary>
        /// Show message box if an error occurs in the datagridview (e.g. missing entries)
        /// I prefer this event to all validating events including errorText - does not work properly...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvModelUserRoles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Cell must contain a value.","Promoveo Addin");
        }

        /// <summary>
        /// Make sure that the data on the second tab is refreshed and shows all edits 
        /// of the first tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcModelUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcModelUsers.SelectedIndex == 1)
            {
                RefreshRoleAssignmentTab();
            }

        }









    }
}
