using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    [DataContract]
    public class ProcessModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ModelName { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public int FK_PublishingPlatformUser { get; set; }
        [DataMember]
        public int FK_Configuration { get; set; }
        [DataMember]
        public string AcknowledgeState { get; set; }
    }
}
