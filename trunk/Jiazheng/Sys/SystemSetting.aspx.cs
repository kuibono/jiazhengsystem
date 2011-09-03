using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Sys
{
    public partial class SystemSetting : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SysInfo i = new SysInfo();
            //i.Copyright = "kuibono@163.com";
            //i.SalerSalaryPercent = 30;
            //i.SystemOpen = true;

            //i.WorkerSalaryPercent = 0;

            //SaveSystemInfo(i);

            if (!IsPostBack)
            {
                txt_Copyright.Text = SystemInfo.Copyright;
                txt_SalerSalaryPercent.Text = SystemInfo.SalerSalaryPercent.ToString();
                //txt_SysTitle.Text = SystemInfo.SysTitle;

            }

            
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "27";
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            this.IsAdd = "false";

            SystemInfo.Copyright = txt_Copyright.Text;
            SystemInfo.SalerSalaryPercent = txt_SalerSalaryPercent.Text.ToInt32();
            SystemInfo.SysTitle = "LJ Jiazheng Management System";
            

            base.OnEdit();

            SaveSystemInfo(SystemInfo);
            Js.AlertAndGoback("保存成功！");
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
