using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Card
{
    public partial class CardEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSysDataContext dsd = new DataSysDataContext();
                ZCard m = new ZCard();
                if (WS.RequestInt("id") > 0)
                {
                    m = (from u in dsd.ZCard where u.Id == WS.RequestInt("id") select u).First();
                    txt_CardNumber.Text = m.CardNumber.ToString();
                    txt_HourSum.Text = m.HourSum.ToString();
                    txt_HourLeft.Text = m.HourLeft.ToString();
                    txt_VTime.Text = m.VTime.ToDateTime().ToString("yyyy-MM-dd");
                    //txt_Status.Text = m.Status.ToString();
                    ddl_Status.SetValue(m.Status.Split(','));
                }
                else
                {
                    txt_VTime.Text = DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd");
                }



            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "29";//设置菜单编号
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            int id = WS.RequestInt("id");
            DataSysDataContext dsd = new DataSysDataContext();
            ZCard m = new ZCard();
            var l = from li in dsd.ZCard where li.Id == id select li;
            if (id > 0 && l.Count() > 0)
            {
                m = l.First();
            }
            m.CardNumber = txt_CardNumber.Text.TrimDbDangerousChar();
            m.HourSum = txt_HourSum.Text.ToDecimal();
            m.HourLeft = txt_HourLeft.Text.ToDecimal();
            m.VTime = txt_VTime.Text.ToDateTime();
            m.Status = ddl_Status.SelectedValue.TrimDbDangerousChar();

            if (id > 0 && l.Count() > 0)
            {
                //编辑
                this.IsAdd = "false";
            }
            else
            {
                if ((from e in dsd.ZCard where e.CardNumber==txt_CardNumber.Text select e).Count()>0)
                {
                    Js.AlertAndGoback("对不起，这个卡号已经存在于系统中，请填写其他卡号。");
                    return;
                }
                m.HourLeft = m.HourSum;

                this.IsAdd = "true";
                dsd.ZCard.InsertOnSubmit(m);
            }

            base.OnEdit();
            dsd.SubmitChanges();

            Js.AlertAndChangUrl("保存成功！", "CardList.aspx");
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
