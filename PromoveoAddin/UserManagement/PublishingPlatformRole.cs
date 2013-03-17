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
        public PublishingPlatformRole()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PublishingPlatformRole_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'promoveoDataSet.PublishingPlatformRole' table. You can move, or remove it, as needed.
            this.publishingPlatformRoleTableAdapter.Fill(this.promoveoDataSet.PublishingPlatformRole);

        }

        private void dgdRoles_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(promoveoDataSet.HasChanges())
            {
                publishingPlatformRoleTableAdapter.Update(promoveoDataSet.PublishingPlatformRole);
            }
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
            foreach (DataRow item in pmDal.GetProcessModels().Rows)
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
    }
}
