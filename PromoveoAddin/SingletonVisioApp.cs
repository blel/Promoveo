using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin
{
    public class SingletonVisioApp
    {
        //Fields
        private Visio.Application _visioApp;
        private static  SingletonVisioApp _singletonVisioApp;

        //Properties
        public Visio.Application VisioApp { get { return _visioApp; } }


        //private Constructor
        private SingletonVisioApp() { }

        //getInstance
        public static SingletonVisioApp GetCurrentVisioInstance()
        {
            if (_singletonVisioApp == null)
            {
                
                _singletonVisioApp = new SingletonVisioApp();
                _singletonVisioApp._visioApp = (Visio.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Visio.Application");
            }
            return _singletonVisioApp;
        }
    }
}
