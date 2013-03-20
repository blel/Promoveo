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
            
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);
            if (this.cmbConfiguration.Items.Count > 0)
            {
                _bsModelUserRoles = new BindingSource();
                _bsModelUserRoles.DataSource = new ModelUserRolesDAL().GetModelUserRoles(Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]));
                this.dgvModelUserRoles.DataSource = _bsModelUserRoles;

                //dont show technical keys (but keep them in the table)
                dgvModelUserRoles.Columns["Id"].Visible = false ;
                dgvModelUserRoles.Columns["FK_Configuration"].Visible=false;
            }
        }

        private void dgvModelUserRoles_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //update the foreign key cell
            dgvModelUserRoles["FK_Configuration", e.RowIndex].Value = GetConfigurationID();
        }


        private int GetConfigurationID()
        {
            if (this.cmbConfiguration.Items.Count > 0 && this.cmbConfiguration.SelectedItem != null)
                return Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            return 0;
        }

        private void dgvModelUserRoles_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //update the table to the database
            ModelUserRolesDAL modelUserDAL = new ModelUserRolesDAL();
            DataView bsDataView = (DataView)_bsModelUserRoles.List;
            Data.PromoveoDataSet.ModelUserGroupDataTable bsmodelUserGroupTable = (Data.PromoveoDataSet.ModelUserGroupDataTable)bsDataView.Table;   
            modelUserDAL.Update(bsmodelUserGroupTable);
        }


    }
}
