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
            var l = from m in dsd.ZEmployees select m;

            l = l.Where(p => p.UserNo.IndexOf(txt_UserNo.Text) > -1);
            l = l.Where(p => p.UserName.IndexOf(txt_UserName.Text) > -1);

            if (rbl_Sex.SelectedValue!="")
            {
                l = l.Where(p => p.Sex==rbl_Sex.SelectedValue);
            }

            l = l.Where(p => p.Tel.IndexOf(txt_Tel.Text) > -1 || p.MobilePhone.IndexOf(txt_Tel.Text) > -1);

            if (rbl_UserType.SelectedValue!="")
            {
                l = l.Where(p => p.UserType == rbl_UserType.SelectedValue);
            }
            
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
                foreach (int id in Ids)
                {
                    dsd.ZEmployees.Delete(p => p.Id==id);
                }
                
            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "EmployeesList.aspx");
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
