using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin.MasterDataManagement
{
    public partial class frmGetShapeDataSource : Form
    {
        Visio.Application _app;
        public frmGetShapeDataSource()
        {
            InitializeComponent();
             _app = SingletonVisioApp.GetCurrentVisioInstance().VisioApp;
            MasterDataManagement.ConnectionStringHelper connectionStringHelper = new ConnectionStringHelper();
            this.txtDBServer.Text = connectionStringHelper.GetDBServer();
            this.txtDBName.Text = connectionStringHelper.GetDBName();
            this.txtModelOwnerView.Text = Resources.Resources.ModelOwnerView;
            this.txtModelUserRoleView.Text = Resources.Resources.ModelUserRoleView;
        }

        private void btnGetShapeData_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;";
                connString += "Initial Catalog=" + txtDBName.Text + ";";
                connString += "Data Source=" + txtDBServer.Text + ";";

                string[] PrimaryKeys = new string[1];
                PrimaryKeys[0] = "Id";

                if (!IsDataRecordsetAvailable(txtModelUserRoleView.Text))
                {
                    string sqlCommand = "select * from \"" + txtDBName.Text + "\".\"dbo\".\"" + txtModelUserRoleView.Text + "\" WHERE FK_Configuration = " + this.cmbConfiguration.SelectedValue.ToString();
                    _app.ActiveDocument.DataRecordsets.Add(connString, sqlCommand, 0, txtModelUserRoleView.Text);
                    _app.ActiveDocument.DataRecordsets.ItemFromID[GetDataRecordsetIndex(txtModelUserRoleView.Text)].SetPrimaryKey(Visio.VisPrimaryKeySettings.visKeySingle, PrimaryKeys);
                }

                if (!IsDataRecordsetAvailable(this.txtModelOwnerView.Text))
                {
                    string sqlCommand = "select * from \"" + txtDBName.Text + "\".\"dbo\".\"" + txtModelOwnerView.Text + "\" WHERE FK_Configuration = " + this.cmbConfiguration.SelectedValue.ToString();
                    _app.ActiveDocument.DataRecordsets.Add(connString, sqlCommand, 0, txtModelOwnerView.Text);
                    _app.ActiveDocument.DataRecordsets.ItemFromID[GetDataRecordsetIndex(txtModelOwnerView.Text)].SetPrimaryKey(Visio.VisPrimaryKeySettings.visKeySingle, PrimaryKeys);
                    _app.ActiveDocument.DataRecordsets.ItemFromID[GetDataRecordsetIndex(txtModelOwnerView.Text)].DataColumns["Email"].SetProperty(Visio.VisDataColumnProperties.visDataColumnPropertyHyperlink, true);
                }

                _app.ActiveWindow.Windows.ItemFromID[(short)Visio.VisWinTypes.visWinIDExternalData].Visible = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                
        }

        private bool IsDataRecordsetAvailable(string name)
        {
            return (from cc in _app.ActiveDocument.DataRecordsets.Cast<Visio.DataRecordset>()
                    where cc.Name == name
                    select cc).Count() > 0;
        }

        private int GetDataRecordsetIndex(string name)
        {
            int index = -1;
            for (int i = 1; i <= _app.ActiveDocument.DataRecordsets.Count; i++)
            {
                if (_app.ActiveDocument.DataRecordsets[i].Name == name)
                    index = i;
            }
            return index;
        }

        private void frmGetShapeDataSource_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'promoveoDataSet.Configuration' table. You can move, or remove it, as needed.
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);

        }

    }
}
