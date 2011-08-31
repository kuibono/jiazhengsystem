using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
namespace Jiazheng
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Voodoo.Business.BasePage b=new Voodoo.Business.BasePage();
            Result result = b.UserLogin(txt_UserName.Text.TrimDbDangerousChar(), txt_Password.Text.TrimDbDangerousChar());
            if (result.Success==false)
            {
                Js.AlertAndChangUrl(result.Text, "Login.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}
