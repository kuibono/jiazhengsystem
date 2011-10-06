using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.HandBill
{
    public partial class HandBillEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSysDataContext dsd = new DataSysDataContext();

                ddl_User.DataSource = from u in dsd.ZEmployees where u.UserType == "宣传" select u;
                ddl_User.DataTextField = "UserName";
                ddl_User.DataValueField = "Id";
                ddl_User.DataBind();

                ZHandBill m = new ZHandBill();
                if (WS.RequestInt("id") > 0)
                {
                    m = (from u in dsd.ZHandBill where u.id == WS.RequestInt("id") select u).First();
                    txt_DiliverCount.Text = m.DiliverCount.ToString();
                    txt_ViewCount.Text = m.ViewCount.ToString();
                    txt_BackCount.Text = m.BackCount.ToString();
                    txt_WorkTime.Text = m.WorkTime.ToDateTime().ToString("yyyy-MM-dd");
                    ddl_User.SetValue(m.Userid.ToS().Split(','));
                }
                else
                {
                    txt_WorkTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }



            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "34";//设置菜单编号
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            int id = WS.RequestInt("id");
            DataSysDataContext dsd = new DataSysDataContext();
            ZHandBill m = new ZHandBill();
            var l = from li in dsd.ZHandBill where li.id == id select li;
            if (id > 0 && l.Count() > 0)
            {
                m = l.First();
            }
            m.DiliverCount = txt_DiliverCount.Text.ToInt32();
            m.ViewCount = txt_ViewCount.Text.ToInt32();
            m.BackCount = txt_BackCount.Text.ToInt32();
            m.WorkTime = txt_WorkTime.Text.ToDateTime();
            m.Userid = ddl_User.SelectedValue.ToInt32();
            m.UserName = ddl_User.SelectedItem.Text;

            if (id > 0 && l.Count() > 0)
            {
                //编辑
                this.IsAdd = "false";
            }
            else
            {
                this.IsAdd = "true";
                dsd.ZHandBill.InsertOnSubmit(m);
            }

            base.OnEdit();
            dsd.SubmitChanges();

            Js.AlertAndChangUrl("保存成功！", "HandBillList.aspx");
        }

        /// <summary>
        /// 编辑按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
