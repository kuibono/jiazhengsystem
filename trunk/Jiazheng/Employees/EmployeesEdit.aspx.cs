using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Employees
{
    public partial class EmployeesEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            DataSysDataContext dsd = new DataSysDataContext();
            cbl_Workable.DataSource = from l in dsd.ZWorkType select l;
            cbl_Workable.DataTextField = "Name";
            cbl_Workable.DataValueField = "id";
            cbl_Workable.DataBind();

            int id = WS.RequestInt("id");
            if (id > 0)
            {

                var l = from emp in dsd.ZEmployees where emp.Id == id select emp;
                if (l.Count() == 0)
                {
                    return;
                }

                ZEmployees e = l.First();
                rbl_UserType.SelectedValue = e.UserType;
                txt_UserName.Text = e.UserName;
                txt_UserNo.Text = e.UserNo;
                rbl_Sex.SelectedValue = e.Sex;
                txt_Birthday.Text = e.Birthday.ToDateTime().ToString("yyyy-MM-dd");
                txt_Tel.Text = e.Tel;
                txt_MobilePhone.Text = e.MobilePhone;
                txt_Address.Text = e.Address;
                txt_JoinTime.Text = e.JoinTime.ToDateTime().ToString("yyyy-MM-dd");

                //可完成工作
                cbl_Workable.SetValue(e.WorkAble.Split(','));

                txt_SalaryDegree.Text = e.SalaryDegree.ToString();
                cb_IsFree.Checked = e.IsFree.ToBoolean();
                txt_Remark.Text = e.Remark;

            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "15";
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            int id = WS.RequestInt("id");

            ZEmployees em = new ZEmployees();

            if (id > 0)
            {
                var l = from emp in dsd.ZEmployees where emp.Id == id select emp;
                if (l.Count() == 0)
                {
                    return;
                }
                else
                {
                    em = l.First();
                }
            }

            em.UserType = rbl_UserType.SelectedValue;
            em.UserName = txt_UserName.Text.TrimDbDangerousChar();
            em.UserNo = txt_UserNo.Text.TrimDbDangerousChar();
            em.Sex = rbl_Sex.SelectedValue;
            em.Birthday = txt_Birthday.Text.ToDateTime();
            em.Tel = txt_Tel.Text.TrimDbDangerousChar();
            em.MobilePhone = txt_MobilePhone.Text.TrimDbDangerousChar();
            em.Address = txt_Address.Text.TrimDbDangerousChar();
            em.JoinTime = txt_JoinTime.Text.ToDateTime();
            em.WorkAble = cbl_Workable.GetValues();
            em.SalaryDegree = txt_SalaryDegree.Text.ToInt32();
            em.IsFree = cb_IsFree.Checked;
            em.Remark = txt_Remark.Text.TrimDbDangerousChar();

            if (id > 0)
            {
                this.IsAdd = "false";
            }
            else
            {
                this.IsAdd = "true";
                dsd.ZEmployees.InsertOnSubmit(em);
            }
            base.OnEdit();
            dsd.SubmitChanges();
            Js.AlertAndChangUrl("保存成功！", "EmployeesList.aspx");

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
