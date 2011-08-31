using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voodoo;
using System.Data;
using Voodoo.Data;
using Voodoo.Data.DbHelper;

namespace Jiazheng.Tools
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    public class Exist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string tableName = WS.RequestString("tableName");
            string columnName = WS.RequestString("columnName");
            string q = WS.RequestString("q");
            int id = WS.RequestInt("id");

            if (tableName.Length == 0 || columnName.Length == 0)
            {
                return;
            }

            IDbHelper Sql = new SqlHelper(System.Configuration.ConfigurationManager.ConnectionStrings["Voodoo.Business.Properties.Settings.RoleSysConnectionString"].ToString());
            string str_sql = string.Format("select count(0) from [{0}] where [{1}]='{2}' and [Id] <>'{3}'", tableName, columnName, q, id.ToString());
            int itemCount = Sql.ExecuteScalar(CommandType.Text, str_sql).ToInt32();

            if (itemCount>0)
            {
                context.Response.Write("true".StringToJson());
            }
            else
            {
                context.Response.Write("false".StringToJson());
            }
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
