using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;


namespace Jiazheng.Card
{
    public partial class CardList : BasePage
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
            var l = from m in dsd.ZCard
                    where
                        //m.Id.IndexOf(txt_Id.Text) > -1 &&
                        m.CardNumber.IndexOf(txt_CardNumber.Text) > -1
                        //m.HourSum.IndexOf(txt_HourSum.Text) > -1 &&
                        //m.HourLeft.IndexOf(txt_HourLeft.Text) > -1 &&
                        //m.VTime.IndexOf(txt_VTime.Text) > -1 &&
                        //m.Status.IndexOf(txt_Status.Text) > -1
                    select m;
            if (ddl_Status.SelectedValue!="")
            {
                l = l.Where(p => p.Status == ddl_Status.SelectedValue);
            }
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "28";//需要设置
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.ZCard.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                dsd.ZCard.Delete(p => p.Id.InArray(Ids));
            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "ZCardList.aspx");
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
