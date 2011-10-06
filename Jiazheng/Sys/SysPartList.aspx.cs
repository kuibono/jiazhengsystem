using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Business;
using System.Data;
using Voodoo.LinqExt;

namespace Jiazheng.Sys
{
    public partial class SysPartList : BasePage
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


        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            List<SysPart> sp = (from parts in dsd.SysPart select parts).ToList();

            pager.RecordCount = sp.Count();

            list.DataSource = sp.Skip(pager.PageSize * (pager.CurrentPageIndex - 1)).Take(pager.PageSize);
            list.DataBind();



        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "2";
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.SysPart.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                foreach (int id in Ids)
                {
                    dsd.SysPart.Delete(p => p.Id == id);
                }

            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "?");
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
