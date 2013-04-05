using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace PromoveoAddin.ServiceClient
{
    public abstract class AbstractBindingFactory
    {
        public abstract Binding CreateBinding();
    }
}
