using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Context.Session.Contents.SessionID
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //every refresh webpage
            Response.Write("Begin Request");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //every refresh webpage
            Response.Write("End Request");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //every refresh webpage
            Response.Write("Authenticate Request");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Response.Write("a error");
            //Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
