using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;

namespace Jiazheng.User
{
    public partial class UserList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("action") == "delete" && WS.RequestInt("id") > 0 && !IsPostBack)
            {
                OnDelete();
            }
            if (!IsPostBack)
            {
                DataSysDataContext dsd = new DataSysDataContext();


                ddl_Group.DataSource = from g in dsd.Group where g.Id != 4 select g;
                ddl_Group.DataTextField = "Name";
                ddl_Group.DataValueField = "id";
                ddl_Group.DataBind();
                ddl_Group.Items.Add(new ListItem("不限", ""));
                ddl_Group.SelectedValue = "";
                BindData();
            }


        }

        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            var l = from u in dsd.User
                    from g in dsd.Group
                    where u.GroupId == g.Id && u.GroupId != 4
                        && u.UserName.IndexOf(txt_Name.Text) > -1
                    select new { u.Id, u.Sex, u.Status, u.UserName, u.Birthday, GroupName = g.Name };
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "7";
            base.OnInit(e);
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
                    dsd.User.Delete(p => p.Id == id);
                }

            }

            base.OnDelete();
            Js.AlertAndChangUrl("删除成功！", "?");
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            OnDelete();
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
    }
}
