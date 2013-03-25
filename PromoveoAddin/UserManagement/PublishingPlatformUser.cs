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










        private void dgvUsers_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (promoveoDataSet.HasChanges())
            {
                publishingPlatformUserTableAdapter.Update(promoveoDataSet.PublishingPlatformUser);
            }
        }
    }
}
