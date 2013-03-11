using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ServiceClient
{
    [Serializable]
    [XmlRoot(Namespace = "http://schemas.microsoft.com/office/infopath/2007/PartnerControls")]
    public class Person
    {
        public string DisplayName { get; set; }
        public string AccountId { get; set; }
        public string AccountType { get; set; }

    }
}
