using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void PrepareObjects(int configurationID)
        {
            _modelUsers = new List<SerializableModelUser>();
            ProcessModelService.ProcessModelClient processModelClient = new ProcessModelService.ProcessModelClient();

            IList<ProcessModelService.ProcessModel> processModels = processModelClient.GetProcessModelsByConfigID(configurationID);
            foreach (ProcessModelService.ProcessModel processModel in processModels)
            {
                SerializableModelUser modelUser = new SerializableModelUser();
                modelUser.Model = processModel.ModelName;

                foreach (ProcessModelService.User userRow in processModelClient.GetUsers(modelUser.Model))
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
