using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;

namespace Jiazheng.Customer
{
    public partial class CustomerList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {
                OnDelete();
            }
            if (!IsPostBack)
            {
                BindData();

                //搜索区域

            }
        }

        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            var l = from cus in dsd.ViewCustomerList select cus;
            l = l.Where(m => m.UserName.IndexOf(txt_Name.Text) > -1 &&
                             m.CardNo.IndexOf(txt_CardNo.Text) > -1 &&
                             (m.Tel.IndexOf(txt_Tel.Text) > -1 || m.MobilePhone.IndexOf(txt_Tel.Text) > -1) &&
                             m.HomeName.IndexOf(txt_HomeName.Text) > -1
                            );
            if (rbl_Sex.SelectedValue != "")
            {
                l = l.Where(m => m.Sex == rbl_Sex.SelectedValue);
            }

            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "13";
            base.OnInit(e);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            BindData();
            pager.CurrentPageIndex = 1;
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            OnDelete();
            DataBind();
        }
        protected void pager_PageChanged(object sender, EventArgs e)
        {

        }

        public override void OnDelete()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {

                dsd.SysPart.Delete(p => p.Id == WS.RequestInt("id"));

            }
            if (IsPostBack)
            {
                int[] Ids = WS.RequestString("ids").Split(',').ToIntArray();
                foreach (int id in Ids)
                {
                    dsd.ZCustomer.Delete(p => p.Id == id);
                }

            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "?");
        }

    }
}
