using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;
using Voodoo.LinqExt;


namespace Jiazheng.Card
{
    public partial class CardConsumeList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WS.RequestString("cardno") != "")
            {
                txt_CardNo.Text = WS.RequestString("cardno");
            }
            
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            var l = from m in dsd.ZCardConsume
                    where
                        //m.id.IndexOf(txt_id.Text) > -1 &&
                        //m.CardId.IndexOf(txt_CardId.Text) > -1 &&
                        m.CardNo.IndexOf(txt_CardNo.Text) > -1 
                        //m.ConsumeHour.IndexOf(txt_ConsumeHour.Text) > -1 &&
                        //m.ConsumeTime.IndexOf(txt_ConsumeTime.Text) > -1
                    select m;
            pager.RecordCount = l.Count();
            list.DataSource = l;
            list.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "35";//需要设置
            base.OnInit(e);
        }



        protected void btn_Search_Click(object sender, ImageClickEventArgs e)
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
