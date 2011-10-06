using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.LinqExt;
using Voodoo.Business;

namespace Jiazheng.Sys
{
    public partial class GropList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {
                OnDelete();
            }
            if (!IsPostBack)
            {
                BindData();
            }

        }



        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "4";
            base.OnInit(e);
        }

        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            List<Group> groups = (from g in dsd.Group where g.Name != "超级管理员" select g).ToList();

            pager.RecordCount = groups.Count();

            list.DataSource = groups.Skip(pager.PageSize * (pager.CurrentPageIndex - 1)).Take(pager.PageSize);
            list.DataBind();


        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.Group.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {

                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                foreach (int id in Ids)
                {
                    dsd.Group.Delete(p => p.Id == id);
                }

            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "?");
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {

        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
