using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceClient;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Xml;
 using System.Windows.Forms;

namespace PromoveoAddin.ServiceClient
{
    public class ListsCommunicator
    {

        ListsSoapClient _client;
        public ListsCommunicator(string address)
        {
            _client = new ListsSoapClient("ListsSoap", new System.ServiceModel.EndpointAddress(address));
            //without the follwing lines, I get an impersonation error
            //see http://blog.sharedove.com/adisjugo/index.php/2012/06/09/required-impersonation-level-was-not-provided-exception-on-opening-an-spsite-when-using-wcf/
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            _client.ChannelFactory.Credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
        }

        public ListsCommunicator()
        {
            _client = new ListsSoapClient("ListsSoap");
            //without the follwing lines, I get an impersonation error
            //see http://blog.sharedove.com/adisjugo/index.php/2012/06/09/required-impersonation-level-was-not-provided-exception-on-opening-an-spsite-when-using-wcf/
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            _client.ChannelFactory.Credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
        }

        public string GetList(string listName)
        {
            XmlElement result = _client.GetList(listName);
            return result.OuterXml;
        }

        public void AddTask(List<SharepointUser> users, string title, string taskListName)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement element = doc.CreateElement("Batch");
            element.SetAttribute("OnError", "continue");
            element.SetAttribute("ListVersion", "1");
            int methodID = 1;
            string body = string.Empty ;
            foreach (SharepointUser user in users)
            {
                // 
                body += string.Format("<Method ID='{0}' Cmd='New'><Field Name = 'Title'>{1}</Field><Field Name = 'AssignedTo'>{2}</Field></Method>",
                    methodID, title, user.GetSPString());
                methodID+=1;
                                                       
            }
            element.InnerXml= body;
            

            try{
                var result = _client.UpdateListItems(taskListName, element);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
