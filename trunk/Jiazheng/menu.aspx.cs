using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng
{
    public partial class menu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            //
            int id=WS.RequestInt("id",11);
            DataSysDataContext dsd=new DataSysDataContext();
            var menus = from g in dsd.SysPart where g.ParentId == id && g.Display==true && g.MenuGroup.Length>0 select g;
            var groups = from g in menus group g by g.MenuGroup into gr select new { Key=gr.Key };

            list.DataSource = groups;
            list.DataBind();

            for (int i = 0; i < list.Items.Count;i++ )
            {
                Repeater r = (Repeater)list.Items[i].FindControl("subList");
                r.DataSource = from item in menus where item.MenuGroup == groups.ToList()[i].Key select item;
                r.DataBind();
            }
            
 
        }




        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "10";
            base.OnInit(e);
        }

        protected void list_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            
        }
    }
}
