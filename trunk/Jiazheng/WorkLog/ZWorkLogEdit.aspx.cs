using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.WorkLog
{
    public partial class ZWorkLogEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataSysDataContext dsd = new DataSysDataContext();




                cbl_ToolIds.DataSource = from l in dsd.ZTools select l;
                cbl_ToolIds.DataTextField = "Name";
                cbl_ToolIds.DataValueField = "id";
                cbl_ToolIds.DataBind();


                ddl_CustomerId.DataSource = from l in dsd.ZCustomer select new { name = l.UserName + "-" + l.HomeName, l.Id };
                ddl_CustomerId.DataTextField = "name";
                ddl_CustomerId.DataValueField = "id";
                ddl_CustomerId.DataBind();

                ddl_CustomerId.Items.Add(new ListItem("--新客户--", "0"));
                ddl_CustomerId.SelectedValue = "0";

                cbl_EmployeesNames.DataSource = from l in dsd.ZEmployees where l.UserType == "保洁" select l;
                cbl_EmployeesNames.DataTextField = "UserName";
                cbl_EmployeesNames.DataValueField = "id";
                cbl_EmployeesNames.DataBind();

                var workralation = from r in dsd.ZWorkEmployeesRelation where r.WorkLogId == WS.RequestInt("id") select r;

                var ems = from em in dsd.ZEmployees
                          join
                          ra in workralation
                          on em.Id equals ra.EmployeesId

                          select new { userid = em.Id, em.UserName, check = ra.id > 0, ra.Salary, ra.WorkLogId };


                list.DataSource = ems;
                list.DataBind();

                ZWorkLog m = new ZWorkLog();
                if (WS.RequestInt("id") > 0)
                {
                    m = (from u in dsd.ZWorkLog where u.Id == WS.RequestInt("id") select u).First();
                    //txt_CustomerId.Text = m.CustomerId.ToString();
                    ddl_CustomerId.SelectedValue = m.CustomerId.ToString();
                    txt_CustomerName.Text = m.CustomerName.ToString();
                    rbl_Sex.SetValue(m.Sex.Split(','));
                    txt_Tel.Text = m.Tel.ToString();
                    txt_MobilePhone.Text = m.MobilePhone.ToString();
                    txt_WorkTime.Text = m.WorkTime.ToString();
                    txt_WorkContent.Text = m.WorkContent.ToString();
                    txt_HomeName.Text = m.HomeName.ToString();
                    txt_Address.Text = m.Address.ToString();
                    txt_WorkHour.Text = m.WorkHour.ToString();
                    //txt_EmployeesIds.Text = m.EmployeesIds.ToString();
                    //txt_EmployeesNames.Text = m.EmployeesNames.ToString();
                    cbl_EmployeesNames.SetValue(m.EmployeesIds.Split(','));
                    //txt_ToolIds.Text = m.ToolIds.ToString();
                    cbl_ToolIds.SetValue(m.ToolIds.Split(','));
                    txt_PayMoney.Text = m.PayMoney.ToString();
                    cb_IsDelete.Checked = m.IsDelete.ToBoolean();
                    cb_IsFinished.Checked = m.IsFinished.ToBoolean();
                    txt_Customerappraise.Text = m.Customerappraise.ToString();
                    txt_Remark.Text = m.Remark.ToString();
                }

                if (WS.RequestInt("uid") > 0 && WS.RequestInt("id") < 0)
                {
                    var l = from li in dsd.ZCustomer where li.Id == WS.RequestInt("uid") select li;
                    if (l.Count() > 0)
                    {
                        ZCustomer cus = l.First();
                        txt_CustomerName.Text = cus.UserName;
                        txt_Tel.Text = cus.Tel;
                        txt_MobilePhone.Text = cus.MobilePhone;
                        txt_HomeName.Text = cus.HomeName;
                        txt_Address.Text = cus.Address;
                        rbl_Sex.SetValue(cus.Sex.Split(','));

                        ddl_CustomerId.SelectedValue = cus.Id.ToS();
                    }
                }

            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "21";//设置菜单编号
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            int id = WS.RequestInt("id");
            DataSysDataContext dsd = new DataSysDataContext();
            ZWorkLog m = new ZWorkLog();
            var l = from li in dsd.ZWorkLog where li.Id == id select li;
            if (id > 0 && l.Count() > 0)
            {
                m = l.First();
            }
            m.CustomerId = ddl_CustomerId.SelectedValue.ToInt32(0);
            m.CustomerName = txt_CustomerName.Text.TrimDbDangerousChar();
            m.Tel = txt_Tel.Text.TrimDbDangerousChar();
            m.MobilePhone = txt_MobilePhone.Text.TrimDbDangerousChar();
            m.WorkTime = txt_WorkTime.Text.ToDateTime();
            m.WorkContent = txt_WorkContent.Text.TrimDbDangerousChar();
            m.HomeName = txt_HomeName.Text.TrimDbDangerousChar();
            m.Address = txt_Address.Text.TrimDbDangerousChar();
            m.WorkHour = txt_WorkHour.Text.ToInt32();
            m.EmployeesIds = cbl_EmployeesNames.GetValues();
            m.EmployeesNames = cbl_EmployeesNames.GetTexts();
            m.ToolIds = cbl_ToolIds.GetValues();
            m.PayMoney = txt_PayMoney.Text.ToInt32();
            m.IsDelete = cb_IsDelete.Checked;
            m.IsFinished = cb_IsFinished.Checked;
            m.Customerappraise = txt_Customerappraise.Text.ToInt32(0);
            m.Remark = txt_Remark.Text.TrimDbDangerousChar();

            if (id > 0 && l.Count() > 0)
            {
                //编辑
                this.IsAdd = "false";
            }
            else
            {
                this.IsAdd = "true";
                dsd.ZWorkLog.InsertOnSubmit(m);
            }

            //如果是新客户 则添加客户信息到系统中
            DataSysDataContext ds = new DataSysDataContext();
            ZCustomer cus = new ZCustomer();
            if (ddl_CustomerId.SelectedValue == "0")
            {

                cus.UserName = txt_CustomerName.Text;
                cus.Sex = rbl_Sex.SelectedValue;
                cus.Tel = txt_Tel.Text;
                cus.MobilePhone = txt_MobilePhone.Text;
                cus.HomeName = txt_HomeName.Text;
                cus.Address = txt_Address.Text;

                cus.IsReg = false;

                ds.ZCustomer.InsertOnSubmit(cus);

            }

            ds.SubmitChanges();

            //扣除金额和工时
            if (ddl_CustomerId.SelectedValue == "0" || txt_PayMoney.Text.ToDecimal() > 0)
            {
                //新客户直接添加支付记录  老用户也可以直接缴费
                ZPayLog p = new ZPayLog();
                p.OperUserId = Opuser.Id;
                p.PayHour = txt_WorkHour.Text.ToInt32();
                p.PayMoney = txt_PayMoney.Text.ToDecimal();
                p.UserId = cus.Id;
                p.UserName = txt_CustomerName.Text;
                dsd.ZPayLog.InsertOnSubmit(p);
            }
            else
            {
                //扣除用户工时，如果剩余工时不足，则跳出错误！
                var cl = from c in dsd.ZCustomer where c.Id == ddl_CustomerId.SelectedValue.ToInt32() select c;
                cus = cl.First();
                if (cus.LeftHour - txt_WorkHour.Text.ToInt32() < 0)
                {
                    Js.AlertAndGoback("客户剩余工时不足，请充值或者直接付款！");
                    return;
                }
                else
                {
                    cus.LeftHour -= txt_WorkHour.Text.ToInt32();

                }
            }

            base.OnEdit();





            dsd.SubmitChanges();



            Js.AlertAndChangUrl("保存成功！", "ZWorkLogList.aspx");
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

        protected void ddl_CustomerId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_CustomerId.SelectedValue != "0")
            {
                Response.Redirect("ZWorkLogEdit.aspx?id=" + WS.RequestInt("id").ToString() + "&uid=" + ddl_CustomerId.SelectedValue);
            }
        }
    }
}
