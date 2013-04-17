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
            UserService.UserClient userClient = new UserService.UserClient();
           

        }

        private void dgvUsers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].HeaderText == "Shortname")
                dgvUsers[e.ColumnIndex, e.RowIndex].Value = dgvUsers[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
        }



        //private void PopulateListView(ListView listView, IEnumerable<Data.PromoveoDataSet.PublishingPlatformUserRow> rows)
        //{
        //    listView.Items.Clear();
        //    foreach (Data.PromoveoDataSet.PublishingPlatformUserRow row in rows)
        //    {
        //        ListViewItem item = listView.Items.Add(row.Id.ToString());
        //        item.SubItems.Add(row.Name);
        //        item.SubItems.Add(row.Shortname);
        //    }
        //}

        private void dgvUsers_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
          //  publishingPlatformUserTableAdapter.Update(promoveoDataSet.PublishingPlatformUser);
        }

        private void dgvUsers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dgvUsers[0, e.RowIndex].FormattedValue.ToString()) ||
                string.IsNullOrWhiteSpace(dgvUsers[1, e.RowIndex].FormattedValue.ToString()) ||
                string.IsNullOrWhiteSpace(dgvUsers[2, e.RowIndex].FormattedValue.ToString()))
            {
                dgvUsers.Rows[e.RowIndex].ErrorText = "All cells must be populated.";
                e.Cancel = true;
            }
            else
            {
                dgvUsers.Rows[e.RowIndex].ErrorText = string.Empty;
            }

        }







    }
}
