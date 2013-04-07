using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Linq;

namespace GetUserWebPart.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling using
        // the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VisualWebPart1()
        {
        }

        [WebBrowsable(true)]
        [WebDescription("Target of the iFrame")]
        [WebDisplayName("iFrame Content:")]
        [Personalizable(PersonalizationScope.Shared)]
        public string DestinationPath { get; set; }

        [WebBrowsable(true)]
        [WebDescription("Height of the iFrame")]
        [WebDisplayName("Height of the content frame:")]
        [Personalizable(PersonalizationScope.Shared)]
        public string FrameHeight { get; set; }

        [WebBrowsable(true)]
        [WebDescription("Width of the iFrame")]
        [WebDisplayName("Width of the content frame:")]
        [Personalizable(PersonalizationScope.Shared)]
        public string FrameWidth { get; set; }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenUser.Value = SPContext.Current.Web.CurrentUser.LoginName;

            if (!string.IsNullOrEmpty(FrameHeight))
            {
                ContentPage.Attributes["height"] = FrameHeight;
            }
            else
            {
                ContentPage.Attributes["height"] = "768";
            }

            if (!string.IsNullOrEmpty(FrameWidth))
            {
                ContentPage.Attributes["width"] = FrameWidth;
            }
            else
            {
                ContentPage.Attributes["width"] = "1024";
            }

            string requestedPage = Page.Request.QueryString["page"];
            if (!string.IsNullOrEmpty(requestedPage))
            {
                ContentPage.Attributes["src"] = string.Format("{0}?Username={1}&page={2}", DestinationPath, Get4LC(HiddenUser.Value), requestedPage);

            }
            else
            {
                ContentPage.Attributes["src"] = string.Format("{0}?Username={1}", DestinationPath, Get4LC(HiddenUser.Value));
            }
        }

        private string Get4LC(string FourLCWithDomain)
        {
            string[] splitResult = FourLCWithDomain.Split('\\');
            return splitResult.Last();
        }


    }
}
