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
    public partial class GropEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = WS.RequestInt("id");
                if (id < 0)
                {
                    return;
                }

                DataSysDataContext dsd = new DataSysDataContext();
                Group grop = (from g in dsd.Group where g.Id == id select g).First();

                txt_Name.Text = grop.Name;


            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "5";
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            int id = WS.RequestInt("id");

            Group g = new Group();
            if (id>0)
            {
                g = (from gr in dsd.Group where gr.Id == id select gr).First();
            }

            g.Name = txt_Name.Text.TrimDbDangerousChar();

            if (id>0)
            {
                this.IsAdd = "false";
            }
            else
            {
                dsd.Group.InsertOnSubmit(g);
                this.IsAdd = "true";
            }
            base.OnEdit();

            dsd.SubmitChanges();

            Js.AlertAndChangUrl("保存成功！", "GropList.aspx");
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
