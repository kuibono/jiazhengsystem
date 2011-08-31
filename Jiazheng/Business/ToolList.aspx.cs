using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;


namespace Jiazheng.Business
{
    public partial class ToolList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0)
                {
                    OnDelete();
                }
                BindData();
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            var l = from m in dsd.ZTools
                    where
                        //m.Id.IndexOf(txt_Id.Text) > -1 &&
                        m.Name.IndexOf(txt_Name.Text) > -1
                    select m;
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "17";//需要设置
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.ZTools.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                dsd.ZTools.Delete(p => p.Id.InArray(Ids));
            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "ZToolsList.aspx");
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        protected void btn_Search_Click(object sender, ImageClickEventArgs e)
        {
            pager.CurrentPageIndex = 1;
            BindData();
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

    }
}
