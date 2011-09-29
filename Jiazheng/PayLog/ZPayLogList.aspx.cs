using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;


namespace Jiazheng.PayLog
{
    public partial class ZPayLogList : BasePage
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

            var l = from pay in dsd.ZPayLog
                    join em in dsd.ZEmployees
                    on pay.EmployeesId equals em.Id
                    into newlist
                    from ls in newlist.DefaultIfEmpty()
                    select new
                    {
                        pay.Id,
                        pay.UserId,
                        pay.CardNo,
                        pay.PayHour,
                        pay.PayMoney,
                        pay.PayTime,
                        pay.UserName,
                        EmployeesName = ls.UserName
                    };

            l = l.Where(p => p.CardNo.IndexOf(txt_CardNo.Text) > -1);
            l = l.Where(p => p.EmployeesName.IndexOf(txt_EmpoyeesName.Text) > -1);
            l = l.Where(p => p.UserName.IndexOf(txt_UserName.Text) > -1);

            //var l = from m in dsd.ZPayLog
            //        where
            //            //m.Id.IndexOf(txt_Id.Text) > -1 &&
            //            //m.UserId.IndexOf(txt_UserId.Text) > -1 &&
            //            m.UserName.IndexOf(txt_UserName.Text) > -1 
            //            //m.OperUserId.IndexOf(txt_OperUserId.Text) > -1 &&
            //            //m.PayMoney.IndexOf(txt_PayMoney.Text) > -1 &&
            //            //m.PayHour.IndexOf(txt_PayHour.Text) > -1
            //        select m;

            if (WS.RequestInt("cid") > 0)
            {
                l = l.Where(p => p.UserId == WS.RequestInt("cid"));
            }

            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "23";//需要设置
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.ZPayLog.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                foreach (int id in Ids)
                {
                    dsd.ZPayLog.Delete(p => p.Id == id);
                }

            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "ZPayLogList.aspx");
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
