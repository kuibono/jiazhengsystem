using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Salary
{
    public partial class PaySalary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SysInfo i = new SysInfo();
            //i.Copyright = "Kuibono@163.com";
            //i.SalerSalaryPercent = 30;
            //i.SystemOpen = true;
            //i.SysTitle = "绿洁家政管理系统";
            //i.WorkerSalaryPercent = 50;
            //SaveSystemInfo(i);

            if (!IsPostBack)
            {
                txt_Month.Text = DateTime.Now.ToString("yyyy-MM");
                BindData();
            }
        }

        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            int year = txt_Month.Text.Split('-')[0].ToInt32();
            int month = txt_Month.Text.Split('-')[1].ToInt32();

            //var l = dsd.ViewPayCard
            //    .Where(p => 
            //        Convert.ToDateTime(p.PayTime).Year==year &&
            //        Convert.ToDateTime(p.PayTime).Month==month &&
            //        p.CardNo !=null &&
            //        p.CardNo!=""
            //        )
            //    .GroupBy(p => p.EmployeesId)
            //    .Select(p => new
            //    {
            //        Salary = p.Sum(q => q.PayMoney),
            //        SalaryPer = p.Sum(q => q.PayMoney*SystemInfo.SalerSalaryPercent/100),
            //        EmployeesId = p.First().EmployeesId,
            //        Username = p.First().UserName,
            //        month = p.First().PayTime,
            //        BaseSalary = p.First().SalaryDegree,
            //        AllSalary = p.Sum(q => q.PayMoney * SystemInfo.SalerSalaryPercent / 100) + p.First().SalaryDegree
            //    });

            var l = dsd.ViewXuanchuanWorkDetail.ToList();
            if (txt_Month.Text!="")
            {
                l = l.Where(p => p.日期 == txt_Month.Text).ToList();
            }


            list.DataSource = l;
            list.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "26";
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

            var l = dsd.ViewXuanchuanWorkDetail.ToList();
            if (txt_Month.Text != "")
            {
                l = l.Where(p => p.日期 == txt_Month.Text).ToList();
            }

            
            Response.Clear();
            Voodoo.IO.ExcelHelper.ResponseExcel(l.ToDataTable(p => new object[] { l }), txt_Month.Text + "-Baojie");
            Response.End();
        }
    }
}
