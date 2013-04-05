using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoveoAddin.ServiceClient
{
    public class SharepointUser
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string GetSPString()
        {
            return ID + ";#" + Name;
        }



    }
}
