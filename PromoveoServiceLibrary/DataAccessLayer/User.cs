using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace PromoveoServiceLibrary.DataAccessLayer
{
    [DataContract]    
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public string Email { get; set; }

    }
}
