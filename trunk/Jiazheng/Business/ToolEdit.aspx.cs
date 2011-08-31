using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Business
{
    public partial class ToolEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSysDataContext dsd = new DataSysDataContext();
                ZTools m = new ZTools();
                if (WS.RequestInt("id") > 0)
                {
                    m = (from u in dsd.ZTools where u.Id == WS.RequestInt("id") select u).First();
                    txt_Name.Text = m.Name.ToString();
                }

                

            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "18";//设置菜单编号
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            int id = WS.RequestInt("id");
            DataSysDataContext dsd = new DataSysDataContext();
            ZTools m = new ZTools();
            var l = from li in dsd.ZTools where li.Id == id select li;
            if (id > 0 && l.Count() > 0)
            {
                m = l.First();
            }

            m.Name = txt_Name.Text.TrimDbDangerousChar();

            if (id > 0 && l.Count() > 0)
            {
                //编辑
                this.IsAdd = "false";
            }
            else
            {
                this.IsAdd = "true";
                dsd.ZTools.InsertOnSubmit(m);
            }

            base.OnEdit();
            dsd.SubmitChanges();

            Js.AlertAndChangUrl("保存成功！", "ToolList.aspx");
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
