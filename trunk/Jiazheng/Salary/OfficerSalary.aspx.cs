using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;


namespace Jiazheng.Salary
{
    public partial class OfficerSalary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "32";
            base.OnInit(e);
        }

        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();



            var l = dsd.ViewOfficerSalary.ToList();


            list.DataSource = l;
            list.DataBind();
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
