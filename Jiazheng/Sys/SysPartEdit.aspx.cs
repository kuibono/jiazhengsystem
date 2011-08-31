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
    public partial class SysPartEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSysDataContext dsd = new DataSysDataContext();

                DropDownList1.DataSource = Voodoo.IO.myDirectory.GetFileList("~/").Where(prop => prop.ToLower().EndsWith(".aspx"));
                DropDownList1.DataBind();
                DropDownList1.Items.Add(new ListItem("--没有文件--",""));

                ddl_Parent.DataSource = from p in dsd.SysPart where p.ParentId == 0 select p;
                ddl_Parent.DataTextField = "MenuTitle";
                ddl_Parent.DataValueField = "id";
                ddl_Parent.DataBind();
                ddl_Parent.Items.Add(new ListItem("--无父菜单--", "0"));
                ddl_Parent.SelectedValue = "0";

                int id = WS.RequestInt("id");
                if (id < 0)
                {
                    return;
                }
                

                SysPart syspart = (from s in dsd.SysPart where s.Id == id select s).ToList().First();

                txt_PartName.Text = syspart.MenuTitle;
                txt_Url.Text = syspart.Url;
                DropDownList1.SelectedValue = syspart.Url;
                cb_Display.Checked = syspart.Display.ToBoolean();
                ddl_Parent.SelectedValue = syspart.ParentId.ToString();
                txt_Group.Text = syspart.MenuGroup;

                
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "2";
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            int id = WS.RequestInt("id");
            SysPart syspart = new SysPart();

            if (id > 0)
            {
                syspart = (from s in dsd.SysPart where s.Id == id select s).ToList().First();
            }

            syspart.Display = cb_Display.Checked;
            syspart.MenuTitle = txt_PartName.Text.TrimDbDangerousChar();
            syspart.Url = DropDownList1.SelectedValue;
            syspart.ParentId = ddl_Parent.SelectedValue.ToInt32();
            syspart.MenuGroup = txt_Group.Text.TrimDbDangerousChar();

            if (id>0)
            {
                //修改
                this.IsAdd = "false";
               
            }
            else
            {
                dsd.SysPart.InsertOnSubmit(syspart);
                this.IsAdd = "true";
            }
            base.OnEdit();
            dsd.SubmitChanges();


            

            Js.AlertAndChangUrl("保存成功！", "SysPartList.aspx");
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
