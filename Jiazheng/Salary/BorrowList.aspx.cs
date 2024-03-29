﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;

namespace Jiazheng.Salary
{
    public partial class BorrowList : BasePage
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
            var l = from m in dsd.ZBorrowSalary
                    where
                        // m.Id.IndexOf(txt_Id.Text) > -1 &&
                        //m.BorrowTime.IndexOf(txt_BorrowTime.Text) > -1 &&
                        //m.BorrowMoney.IndexOf(txt_BorrowMoney.Text) > -1 &&
                        //m.UserID.IndexOf(txt_UserID.Text) > -1 &&
                        m.UserName.IndexOf(txt_UserName.Text) > -1
                    select m;
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "31";//需要设置
            base.OnInit(e);
        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.ZBorrowSalary.Delete(p => p.Id == WS.RequestInt("id"));
            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                foreach (int id in Ids)
                {
                    dsd.ZBorrowSalary.Delete(p => p.Id==id);
                }

            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "ZBorrowSalaryList.aspx");
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
