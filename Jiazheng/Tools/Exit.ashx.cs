using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Jiazheng.Tools
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    public class Exit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Voodoo.Cookies.Cookies.Clear();
            context.Response.Redirect("../Login.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
