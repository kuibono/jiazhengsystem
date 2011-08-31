using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng
{
    public partial class Top : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            var l = from part in dsd.SysPart where part.ParentId == 0 && part.Display == true select part;
            list.DataSource = l;
            list.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "9";
            base.OnInit(e);
        }

    }
}
