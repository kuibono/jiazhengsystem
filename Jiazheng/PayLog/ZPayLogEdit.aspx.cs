using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.PayLog
{
    public partial class ZPayLogEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSysDataContext dsd = new DataSysDataContext();

                ddl_Cus.DataSource = from l in dsd.ZCustomer select l;
                ddl_Cus.DataTextField = "UserName";
                ddl_Cus.DataValueField = "id";
                ddl_Cus.DataBind();

                ddl_Cus.Items.Add(new ListItem("--请选择--", "0"));
                ddl_Cus.SelectedValue = "0";


                ddl_Saler.DataSource = from l in dsd.ZEmployees where l.UserType == "宣传" select l;
                ddl_Saler.DataTextField = "UserName";
                ddl_Saler.DataValueField = "id";
                ddl_Saler.DataBind();

                ddl_Saler.Items.Add(new ListItem("--请选择--", "0"));
                ddl_Saler.SelectedValue = "0";


                ZPayLog m = new ZPayLog();
                if (WS.RequestInt("id") > 0)
                {
                    m = (from u in dsd.ZPayLog where u.Id == WS.RequestInt("id") select u).First();
                    //txt_UserId.Text = m.UserId.ToString();
                    //txt_UserName.Text = m.UserName.ToString();
                    ddl_Cus.SelectedValue = m.UserId.ToString();
                    txt_PayMoney.Text = m.PayMoney.ToString();
                    txt_PayHour.Text = m.PayHour.ToString();
                    ddl_Saler.SelectedValue = m.EmployeesId.ToString();
                }



            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "24";//设置菜单编号
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            int id = WS.RequestInt("id");
            DataSysDataContext dsd = new DataSysDataContext();
            ZPayLog m = new ZPayLog();
            var l = from li in dsd.ZPayLog where li.Id == id select li;
            if (id > 0 && l.Count() > 0)
            {
                m = l.First();
            }
            m.UserId = ddl_Cus.SelectedValue.ToInt32();
            m.UserName = ddl_Cus.SelectedItem.Text;
            m.OperUserId = Opuser.Id;
            m.PayMoney = txt_PayMoney.Text.ToDecimal();
            m.PayHour = txt_PayHour.Text.ToInt32();
            m.EmployeesId = ddl_Saler.SelectedValue.ToInt32();

            if (id > 0 && l.Count() > 0)
            {
                //编辑
                this.IsAdd = "false";
            }
            else
            {
                //增加用户剩余工时
                var l_cus = from c in dsd.ZCustomer where c.Id == m.UserId select c;
                ZCustomer cus = l_cus.First();
                cus.LeftHour += m.PayHour;

                this.IsAdd = "true";
                dsd.ZPayLog.InsertOnSubmit(m);
            }

            base.OnEdit();
            dsd.SubmitChanges();

            Js.AlertAndChangUrl("保存成功！", "ZPayLogList.aspx");
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
