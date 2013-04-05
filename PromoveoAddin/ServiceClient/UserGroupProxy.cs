using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceClient;
using System.Xml;
using System.Windows.Forms;

namespace PromoveoAddin.ServiceClient
{
    public class UserGroupProxy
    {
        UserGroupSoapClient _client;
        public UserGroupProxy()
        {
            _client = new UserGroupSoapClient("UserGroupSoap");
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            _client.ChannelFactory.Credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
        }

        public string GetUserId(string userName)
        {
            try
            {
                XmlElement userInfo = _client.GetUserInfo(userName);
                string userID = userInfo.GetElementsByTagName("User")[0].Attributes["ID"].Value;
                return userID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return string.Empty;
        }

        public SharepointUser GetSharepointUser(string userName)
        {
            SharepointUser spUser = new SharepointUser();
            try
            {
                XmlElement userInfo = _client.GetUserInfo(userName);
                spUser.ID = userInfo.GetElementsByTagName("User")[0].Attributes["ID"].Value;
                spUser.Name = userInfo.GetElementsByTagName("User")[0].Attributes["LoginName"].Value;
                return spUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return spUser;
        }


        public List<SharepointUser> GetSharepointUsers (List<string> users, string serverName)
        {
            List<SharepointUser> spUsers = new List<SharepointUser>();
            foreach (string user in users)
            {
                spUsers.Add(GetSharepointUser(FileHelper.EnsureTailBackslash(serverName)+user));
            }
            return spUsers;
        }


    }
}
