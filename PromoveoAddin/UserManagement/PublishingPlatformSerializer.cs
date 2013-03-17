using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoAddin.Data;
using PromoveoAddin.Data.PromoveoDataSetTableAdapters;
using System.Xml.Serialization;
using System.IO;

namespace PromoveoAddin.UserManagement
{
    public class PublishingPlatformSerializer
    {
        private List<SerializableModelUser> _modelUsers;
        private string _filename;
        
        public PublishingPlatformSerializer(string fileName)
        {
            _filename = fileName;

        }

        public void PrepareObjects()
        {
            _modelUsers = new List<SerializableModelUser>();

            ProcessModelDAL pmDAL = new ProcessModelDAL();
            Data.PromoveoDataSet.ProcessModelDataTable processModels = pmDAL.GetProcessModels();
            foreach (Data.PromoveoDataSet.ProcessModelRow row in processModels.Rows)
            {
                SerializableModelUser modelUser = new SerializableModelUser();
                modelUser.Model = row.ProcessModel;

                foreach (Data.PromoveoDataSet.ProcessModelUsersRow userRow in pmDAL.GetUsers(modelUser.Model).Rows)
                {
                    SerializableUser user = new SerializableUser();
                    user.eMail = userRow.Email;
                    user.Shortname = userRow.Shortname;
                    user.Username = userRow.Name;
                    modelUser.Users.Add(user);
                }
                _modelUsers.Add(modelUser);
            }
        }

        public void SerializeModelUsers()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableModelUser>));
            using (TextWriter tw = new StreamWriter(_filename))
                serializer.Serialize(tw, _modelUsers);
        }


    }
}
