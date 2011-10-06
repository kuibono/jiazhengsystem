using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;

namespace Jiazheng.HandBill
{
    public partial class HandBillList : BasePage
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
            var l = from m in dsd.ZHandBill
                    where
                        // m.id.IndexOf(txt_id.Text) > -1 &&
                        //m.DiliverCount.IndexOf(txt_DiliverCount.Text) > -1 &&
                        //m.ViewCount.IndexOf(txt_ViewCount.Text) > -1 &&
                        // m.BackCount.IndexOf(txt_BackCount.Text) > -1 &&
                        //m.WorkTime.IndexOf(txt_WorkTime.Text) > -1 &&
                        // m.Userid.IndexOf(txt_Userid.Text) > -1 &&
                        m.UserName.IndexOf(txt_UserName.Text) > -1
                    select m;
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "33";//需要设置
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.ZHandBill.Delete(p => p.id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                //dsd.ZHandBill.Delete(p => p.Id.InArray(Ids));
                foreach (int id in Ids)
                {
                    dsd.ZHandBill.Delete(p => p.id == id);
                }
            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "HandBillList.aspx");
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
