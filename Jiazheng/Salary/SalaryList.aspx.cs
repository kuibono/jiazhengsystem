﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Salary
{
    public partial class SalaryList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_Month.Text = DateTime.Now.ToString("yyyy-MM");
                BindData();
            }
        }

        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            //int year = txt_Month.Text.Split('-')[0].ToInt32();
            //int month = txt_Month.Text.Split('-')[1].ToInt32();

            //var l = dsd.ViewUserWorkLog
            //    .Where(p => Convert.ToDateTime(p.WorkTime).Month == month && Convert.ToDateTime(p.WorkTime).Year == year)
            //    .GroupBy(p => p.EmployeesId)
            //    .Select(p => new { 
            //        Salary = p.Sum(q => q.Salary), 
            //        EmployeesId = p.First().EmployeesId, 
            //        Username = p.First().UserName, 
            //        month = p.First().WorkTime,
            //        BaseSalary=p.First().SalaryDegree,
            //        AllSalary = p.Sum(q => q.Salary) + p.First().SalaryDegree
            //    });

            var l = dsd.ViewBaojieWorkDetail.ToList();
            if (txt_Month.Text!="")
            {
                l = l.Where(p => p.日期 == txt_Month.Text).ToList();
            }
            l = l.OrderByDescending(p => p.保洁员).ToList();
            l = l.OrderByDescending(p => p.日期).ToList();
            
            list.DataSource = l;
            list.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "25";
            base.OnInit(e);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            pager.CurrentPageIndex = 1;
            BindData();
        }

        protected void pager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            DataSysDataContext dsd = new DataSysDataContext();

            int year = txt_Month.Text.Split('-')[0].ToInt32();
            int month = txt_Month.Text.Split('-')[1].ToInt32();

            var l = dsd.ViewBaojieWorkDetail.ToList();
            if (txt_Month.Text != "")
            {
                l = l.Where(p => p.日期 == txt_Month.Text).ToList();
            }
            l = l.OrderByDescending(p => p.保洁员).ToList();
            l = l.OrderByDescending(p => p.日期).ToList();

            Response.Clear();
            Voodoo.IO.ExcelHelper.ResponseExcel(l.ToDataTable(p=>new object[]{l}), txt_Month.Text+"-Baojie");
            Response.End();
        }
    }
}
