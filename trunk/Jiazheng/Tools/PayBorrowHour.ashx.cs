using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using Voodoo;
using Voodoo.Business;
using Voodoo.Data;
using Voodoo.Data.DbHelper;

namespace Jiazheng.Tools
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    public class PayBorrowHour : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            IDbHelper Sql = new SqlHelper(System.Configuration.ConfigurationManager.ConnectionStrings["Voodoo.Business.Properties.Settings.RoleSysConnectionString"].ToString());
            int cusId = WS.RequestInt("id");
            if (cusId>0)
            {
                string str_sql = "update ZCustomerBorrowLog set HasPay=1,PayTime=getdate() where HasPay=0 and WorkLogId in(select id from ZWorkLog where CustomerId=" + cusId + ")";
                Sql.ExecuteNonQuery(CommandType.Text, str_sql);
            }

            Js.AlertAndChangUrl("该用户欠工时已经全部还清！", "../Customer/CustomerList.aspx");
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
