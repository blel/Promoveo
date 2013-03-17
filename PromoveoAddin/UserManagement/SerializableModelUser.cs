using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoveoAddin.UserManagement
{
    [Serializable]
    public class SerializableModelUser
    {
        public SerializableModelUser()
        {
            Users = new List<SerializableUser>();
        }
            
        
        public string Model { get; set; }
        public List<SerializableUser> Users { get; set; }
    }

    [Serializable]
    public class SerializableUser
    {
        public string Shortname { get; set; }
        public string Username { get; set; }
        public string eMail { get; set; }
    }

}
