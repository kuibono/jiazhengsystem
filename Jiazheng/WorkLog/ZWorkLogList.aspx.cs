using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;


namespace Jiazheng.WorkLog
{
    public partial class ZWorkLogList : BasePage
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
            var l = from m in dsd.ZWorkLog
                    where
                        //m.Id.IndexOf(txt_Id.Text) > -1 &&
                        //m.CustomerId.IndexOf(txt_CustomerId.Text) > -1 &&
                        m.CustomerName.IndexOf(txt_CustomerName.Text) > -1 &&
                        m.Tel.IndexOf(txt_Tel.Text) > -1 &&
                        //m.MobilePhone.IndexOf(txt_MobilePhone.Text) > -1 &&
                        //m.WorkTime.IndexOf(txt_WorkTime.Text) > -1 &&
                        //m.WorkContent.IndexOf(txt_WorkContent.Text) > -1 &&
                        m.HomeName.IndexOf(txt_HomeName.Text) > -1 
                        //m.Address.IndexOf(txt_Address.Text) > -1 &&
                        //m.WorkHour.IndexOf(txt_WorkHour.Text) > -1 &&
                        //m.EmployeesIds.IndexOf(txt_EmployeesIds.Text) > -1 &&
                        //m.EmployeesNames.IndexOf(txt_EmployeesNames.Text) > -1 &&
                        //m.ToolIds.IndexOf(txt_ToolIds.Text) > -1 &&
                        //m.PayMoney.IndexOf(txt_PayMoney.Text) > -1 &&
                        //m.IsDelete.IndexOf(txt_IsDelete.Text) > -1 &&
                        //m.IsFinished.IndexOf(txt_IsFinished.Text) > -1 &&
                        //m.Customerappraise.IndexOf(txt_Customerappraise.Text) > -1 &&
                        //m.Remark.IndexOf(txt_Remark.Text) > -1
                    select m;
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "2";//需要设置
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.ZWorkLog.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                dsd.ZWorkLog.Delete(p => p.Id.InArray(Ids));
            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "ZWorkLogList.aspx");
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
