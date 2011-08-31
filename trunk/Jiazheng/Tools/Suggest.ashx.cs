using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
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

    public class Suggest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string tableName = WS.RequestString("tableName");
            string columnName = WS.RequestString("columnName");
            string q = WS.RequestString("q");
            StringBuilder sb = new StringBuilder();
            if (tableName.Length == 0 || columnName.Length == 0)
            {
                return;
            }

            IDbHelper Sql = new SqlHelper(System.Configuration.ConfigurationManager.ConnectionStrings["Voodoo.Business.Properties.Settings.RoleSysConnectionString"].ToString());
            string m_where = "select distinct top 9 " + columnName + " from [" + tableName + "] where " + columnName + " like '" + q + "%'";
            DataTable dt = Sql.ExecuteDataTable(m_where);
            int dtCount = dt.Rows.Count;
            for (int i = 0; i < dtCount; i++)
            {
                sb.Append("{name:\"" + dt.Rows[i][0].ToString() + "\"},");
            }
            dt.Clear();
            dt.Dispose();
            context.Response.Write("[");
            context.Response.Write(sb.ToString().TrimEnd(','));
            context.Response.Write("]");


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
