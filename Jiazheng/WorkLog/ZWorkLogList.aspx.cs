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
            var l = from m in dsd.ViewWorkLogList select m;

            l = l.Where(p => p.CustomerName.IndexOf(txt_CustomerName.Text) > -1);
            l = l.Where(p => p.Tel.IndexOf(txt_Tel.Text) > -1 || p.MobilePhone.IndexOf(txt_Tel.Text) > -1);
            l = l.Where(p => p.HomeName.IndexOf(txt_HomeName.Text) > -1);
            if (txt_WorkTime_e.ToDateTime().ToString("yyyy-MM-dd") != "2000-01-01" && txt_WorkTime_s.ToDateTime().ToString("yyyy-MM-dd") != "2000-01-01")
            {
                l = l.Where(p => p.WorkTime > Convert.ToDateTime(txt_WorkTime_s.Text) && p.WorkTime < Convert.ToDateTime(txt_WorkTime_e.Text));
            }
            l = l.Where(p => p.WorkContent.IndexOf(txt_WorkContent.Text) > -1);


            l = l.Where(p => p.users.IndexOf(txt_Worker.Text)>-1);

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
                foreach (int i in Ids)
                {
                    dsd.ZWorkLog.Delete(p => p.Id == i);
                }

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
