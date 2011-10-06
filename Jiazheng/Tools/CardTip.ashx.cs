using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Tools
{

    public class CardTip : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DataSysDataContext dsd = new DataSysDataContext();

            StringBuilder sb = new StringBuilder();
            sb.Append("([");

            var cards = (from c in dsd.ZCard where Convert.ToDateTime(c.VTime).AddDays(2) <= DateTime.Now && Convert.ToDateTime(c.VTime) > DateTime.Now select c).ToList();

            foreach (var c in cards)
            {
                sb.Append("{");
                sb.Append("card:\"" + c.CardNumber + "\"");
                sb.Append("},");
            }
            sb = sb.TrimEnd(',');

            sb.Append("])");

            context.Response.Write(sb.ToString());
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
