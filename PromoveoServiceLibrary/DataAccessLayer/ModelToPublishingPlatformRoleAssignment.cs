using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    [DataContract]
    public class ModelToPublishingPlatformRoleAssignment
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int FK_ProcessModel { get; set; }

        [DataMember]
        public int FK_PublishingPlatformRole { get; set; }
    }
}
