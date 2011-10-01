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
    public partial class BorrowEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSysDataContext dsd = new DataSysDataContext();
                ZBorrowSalary m = new ZBorrowSalary();
                if (WS.RequestInt("id") > 0)
                {
                    m = (from u in dsd.ZBorrowSalary where u.Id == WS.RequestInt("id") select u).First();
                    txt_BorrowTime.Text = m.BorrowTime.ToString();
                    txt_BorrowMoney.Text = m.BorrowMoney.ToString();
                    //txt_UserID.Text = m.UserID.ToString();
                    //txt_UserName.Text = m.UserName.ToString();
                    ddl_User.SetValue(m.UserID.ToString().Split(','));
                    ddl_UserType.SelectedValue = m.UserType.ToString();
                }
                else
                {
                    txt_BorrowTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }

                ddl_UserType_SelectedIndexChanged(sender, e);


            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "30";//设置菜单编号
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            int id = WS.RequestInt("id");
            DataSysDataContext dsd = new DataSysDataContext();
            ZBorrowSalary m = new ZBorrowSalary();
            var l = from li in dsd.ZBorrowSalary where li.Id == id select li;
            if (id > 0 && l.Count() > 0)
            {
                m = l.First();
            }
            m.BorrowTime = txt_BorrowTime.Text.ToDateTime();
            m.BorrowMoney = txt_BorrowMoney.Text.ToDecimal();
            m.UserID = ddl_User.SelectedValue.ToInt32();
            m.UserName = ddl_User.SelectedItem.Text.TrimDbDangerousChar();
            m.UserType = ddl_UserType.SelectedValue.TrimDbDangerousChar();

            if (id > 0 && l.Count() > 0)
            {
                //编辑
                this.IsAdd = "false";
            }
            else
            {
                this.IsAdd = "true";
                dsd.ZBorrowSalary.InsertOnSubmit(m);
            }

            base.OnEdit();
            dsd.SubmitChanges();

            Js.AlertAndChangUrl("保存成功！", "BorrowList.aspx");
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

        protected void ddl_UserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSysDataContext dsd = new DataSysDataContext();

            switch (ddl_UserType.SelectedValue)
            {
                case "宣传":
                    ddl_User.DataSource = from u in dsd.ZEmployees where u.UserType == "宣传" select u;
                    ddl_User.DataTextField = "UserName";
                    ddl_User.DataValueField = "Id";
                    ddl_User.DataBind();
            	break;
                case "保洁":
                ddl_User.DataSource = from u in dsd.ZEmployees where u.UserType == "保洁" select u;
                ddl_User.DataTextField = "UserName";
                ddl_User.DataValueField = "Id";
                ddl_User.DataBind();
                break;

                case "办公室":
                ddl_User.DataSource = from u in dsd.User where u.GroupId==5 select u;
                ddl_User.DataTextField = "UserName";
                ddl_User.DataValueField = "Id";
                ddl_User.DataBind();
                break;
            }
        }
    }
}
