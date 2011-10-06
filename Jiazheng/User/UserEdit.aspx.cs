using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.User
{
    public partial class UserEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                DataSysDataContext dsd=new DataSysDataContext();


                ddl_Group.DataSource = from g in dsd.Group where g.Id!=4 select g;
                ddl_Group.DataTextField = "Name";
                ddl_Group.DataValueField = "id";
                ddl_Group.DataBind();

                Voodoo.Business.User user = new Voodoo.Business.User();
                if (WS.RequestInt("id")>0)
                {
                    user = (from u in dsd.User where u.Id == WS.RequestInt("id") select u).First();
                }

                txt_UserName.Text = user.UserName;
                txt_Pass.Text = user.UserPassword;
                rbl_Sex.SelectedValue = user.Sex;
                txt_Birthday.Text = user.Birthday.ToDateTime().ToString("yyyy-MM-dd");
                txt_Salary.Text = user.Salary.ToString();
                
                rbl_Status.SelectedValue = user.Status;
                ddl_Group.SelectedValue = user.GroupId.ToString();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "8";
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            Voodoo.Business.User user = new Voodoo.Business.User();
            int id = WS.RequestInt("id");

            if (id > 0)
            {
                user = (from u in dsd.User where u.Id == id select u).First();

            }
            else
            {
                int exist= (from u in dsd.User where u.UserName == txt_UserName.Text select u).Count();
                if (exist>0)
                {
                    //已经存在
                    Js.AlertAndGoback("对不起，帐号重复！");
                    return;
                }
            }

            user.Birthday = txt_Birthday.Text.ToDateTime();
            user.GroupId = ddl_Group.SelectedValue.ToInt32();
            user.Sex = rbl_Sex.SelectedValue;
            user.Status = rbl_Status.SelectedValue;
            user.UserName = txt_UserName.Text.TrimDbDangerousChar();
            user.UserPassword = Voodoo.Security.Encrypt.Md5(txt_Pass.Text);
            user.Salary = txt_Salary.Text.ToDecimal();

            if (id > 0)
            {
                //编辑
                this.IsAdd = "false";
            }
            else
            {
                this.IsAdd = "true";
                dsd.User.InsertOnSubmit(user);
            }
            
            base.OnEdit();

            dsd.SubmitChanges();
            Js.AlertAndChangUrl("保存成功！", "UserList.aspx");
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
