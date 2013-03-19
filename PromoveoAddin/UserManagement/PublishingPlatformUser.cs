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
    public partial class PublishingPlatformUser : Form
    {
        public PublishingPlatformUser()
        {
            InitializeComponent();
        }

        private void PublishingPlatformUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'promoveoDataSet.PublishingPlatformRole' table. You can move, or remove it, as needed.
            this.publishingPlatformRoleTableAdapter.Fill(this.promoveoDataSet.PublishingPlatformRole);
            // TODO: This line of code loads data into the 'promoveoDataSet.PublishingPlatformUser' table. You can move, or remove it, as needed.
            this.publishingPlatformUserTableAdapter.Fill(this.promoveoDataSet.PublishingPlatformUser);
            ColumnHeader header = lsvAvailableUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAvailableUsers.Columns.Add("Name");
            lsvAvailableUsers.Columns.Add("Shortname");
            header =lsvAssignedUsers.Columns.Add("Id");
            header.Width = 0;
            lsvAssignedUsers.Columns.Add("Name");
            lsvAssignedUsers.Columns.Add("Shortname");
            


        }

        private void dgvUsers_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvUsers.Columns[e.ColumnIndex].HeaderText == "Shortname")
            //    dgvUsers[e.ColumnIndex, e.RowIndex].Value = dgvUsers[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
        }

        private void dgvUsers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].HeaderText == "Shortname")
                dgvUsers[e.ColumnIndex, e.RowIndex].Value = dgvUsers[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();

        }

        private void tbcUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcUsers.SelectedIndex == 1)
            {
                int roleID=0;
                if (this.cmbSelectRole.SelectedValue != null)
                {
                     roleID = Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
                }
                UserRoleDAL userRoleDAL = new UserRoleDAL();
                PopulateListView(this.lsvAssignedUsers,userRoleDAL.GetAssignedUsers(roleID));
                PopulateListView(this.lsvAvailableUsers, userRoleDAL.GetUnassignedUsers(roleID));
                
                
            }

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


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void cmbSelectRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int roleID = 0;
            if (this.cmbSelectRole.SelectedValue != null)
            {
                roleID= Convert.ToInt32(((DataRowView)this.cmbSelectRole.SelectedValue).Row[0]);
            }
            UserRoleDAL userRoleDAL = new UserRoleDAL();
            PopulateListView(this.lsvAssignedUsers, userRoleDAL.GetAssignedUsers(roleID));
            PopulateListView(this.lsvAvailableUsers, userRoleDAL.GetUnassignedUsers(roleID));
        }

        private void dgvUsers_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (promoveoDataSet.HasChanges())
            {
                publishingPlatformUserTableAdapter.Update(promoveoDataSet.PublishingPlatformUser);
            }
        }
    }
}
