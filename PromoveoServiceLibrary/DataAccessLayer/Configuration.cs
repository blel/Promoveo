using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    [DataContract]
    public class Configuration
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string VisioMasterFilename { get; set; }

    }
}
