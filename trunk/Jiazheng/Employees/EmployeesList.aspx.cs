using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;

namespace Jiazheng.Employees
{
    public partial class EmployeesList : BasePage
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
            var l = from m in dsd.ZEmployees
                    where
                        //m.Id.IndexOf(txt_Id.Text) > -1 &&
                        m.UserNo.IndexOf(txt_UserNo.Text) > -1 &&
                        m.UserName.IndexOf(txt_UserName.Text) > -1 &&
                        m.Sex.IndexOf(txt_Sex.Text) > -1 &&
                        //m.Birthday.IndexOf(txt_Birthday.Text) > -1 &&
                        (m.Tel.IndexOf(txt_Tel.Text) > -1 || m.MobilePhone.IndexOf(txt_Tel.Text) > -1) &&
                        //m.Address.IndexOf(txt_Address.Text) > -1 &&
                        //m.JoinTime.IndexOf(txt_JoinTime.Text) > -1 &&
                        m.WorkAble.IndexOf(txt_WorkAble.Text) > -1
                        //m.SalaryDegree.IndexOf(txt_SalaryDegree.Text) > -1 &&
                        //m.IsFree.IndexOf(txt_IsFree.Text) > -1 &&
                        //m.Remark.IndexOf(txt_Remark.Text) > -1
                    select m;
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "15";//需要设置
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.ZEmployees.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                dsd.ZEmployees.Delete(p => p.Id.InArray(Ids));
            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "ZEmployeesList.aspx");
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
