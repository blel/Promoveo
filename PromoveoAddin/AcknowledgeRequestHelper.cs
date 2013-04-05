using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin
{
    public class AcknowledgeRequestHelper
    {
        int _configurationID;
        Visio.Document _master;
        public AcknowledgeRequestHelper(int configurationID, Visio.Document master)
        {
            _configurationID = configurationID;
            _master = master;
        }

        //TODO: Send the acknowledge request to all users of all models which are not in state Acknowledged of a specific configuration
        public void SendAcknowledgeRequest()
        {
            MasterDataManagement.ProcessModelDAL pmDal = new MasterDataManagement.ProcessModelDAL();
            ServiceClient.UserGroupProxy proxy = new ServiceClient.UserGroupProxy();
            ServiceClient.ListsCommunicator listCommunicator = new ServiceClient.ListsCommunicator();
            foreach (Visio.Page page in _master.Pages)
            {
                Data.PromoveoDataSet.ProcessModelRow processModel = pmDal.GetProcessModels(_configurationID).Where(cc => cc.ProcessModel == page.Name).FirstOrDefault();//TODO: Only with appropriate acknowledge state (currently DBNull error)...
                if (processModel != null)
                {
                    List<string> users = GetUsers(page);
                    List<ServiceClient.SharepointUser> spUsers = proxy.GetSharepointUsers(users, "zenon5000");
                    listCommunicator.AddTask(spUsers, string.Format("Please acknowledge model {0}.", page.Name), "Tasks");
                    processModel.AcknowledgeState = AcknowledgeState.Acknowledged.ToString();
                    Data.PromoveoDataSetTableAdapters.ProcessModelTableAdapter adapter = new Data.PromoveoDataSetTableAdapters.ProcessModelTableAdapter();
                    adapter.Update(processModel);
                }
            }
        }

        private List<string> GetUsers(Visio.Page page)
        {
            List<string> users = new List<string>();
            foreach (Visio.Shape shape in page.Shapes)
            {
                if (shape.Type == (short)Visio.VisShapeTypes.visTypeGroup)
                {
                    foreach (Visio.Shape subshape in shape.Shapes)
                    {
                        if (Convert.ToBoolean(subshape.CellExistsU["Prop._VisDM_Users", (short)0]))
                        {
                            users.AddRange(ExtractUsers(subshape.CellsU["Prop._VisDM_Users"].FormulaU));
                        }
                    }
                }
                if (Convert.ToBoolean(shape.CellExistsU["Prop._VisDM_Users", (short)0]))
                {
                    users.AddRange(ExtractUsers(shape.CellsU["Prop._VisDM_Users"].FormulaU));
                }
            }
            return users.Distinct().ToList();
        }

        private List<string> ExtractUsers(string userString)
        {
            string[] users = userString.Substring(1,userString.Length-2).Split(',');
            return users.Select(cc => cc.Trim()).ToList();

        }


    }
}
public enum AcknowledgeState
{
    Merged,
    MergedAndPublished,
    Acknowledged
}