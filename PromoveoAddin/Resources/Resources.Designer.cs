﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PromoveoAddin.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PromoveoAddin.Resources.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///var MSIE = false;
        ///var ver = 0;
        ///var indexOfMSIE = navigator.userAgent.indexOf(&quot;MSIE&quot;); 
        ///if(indexOfMSIE != -1)
        ///{
        ///	MSIE = true;
        ///	ver = parseFloat(navigator.userAgent.substring(indexOfMSIE + 5, navigator.userAgent.indexOf(&quot;;&quot;, indexOfMSIE)));
        ///}
        ///
        ///var slInstalled = false;
        ///try
        ///{
        ///	var b = null; 
        ///	if (MSIE)
        ///	{
        ///		b = new ActiveXObject(&quot;AgControl.AgControl&quot;);
        ///		slInstalled = true;
        ///	}
        ///	else
        ///	{
        ///		var plugin = navigator.plugins[&quot;Silverlight Plug-In&quot;];
        ///		if (plugin)
        ///		{
        ///			var version = plugin.des [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string frameset {
            get {
                return ResourceManager.GetString("frameset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ProcessModelAndOwner.
        /// </summary>
        internal static string ModelOwnerView {
            get {
                return ResourceManager.GetString("ModelOwnerView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ModelUserGroupUsers.
        /// </summary>
        internal static string ModelUserRoleView {
            get {
                return ResourceManager.GetString("ModelUserRoleView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap print_icon_tcm46_328106 {
            get {
                object obj = ResourceManager.GetObject("print_icon_tcm46_328106", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
