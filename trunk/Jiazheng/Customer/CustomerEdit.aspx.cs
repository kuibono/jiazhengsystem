using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Business;

namespace Jiazheng.Customer
{
    public partial class CustomerEdit : BasePage
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
            DataSysDataContext dsd=new DataSysDataContext();

            int id = WS.RequestInt("id");
            if (id<0)
            {
                return;
            }
            var l = from cus in dsd.ZCustomer where cus.Id == id select cus;
            if (l.Count()==0)
            {
                return;
            }
            ZCustomer c = l.First();
            txt_UserName.Text = c.UserName;
            
            rbl_Sex.SelectedValue = c.Sex;
            txt_Tel.Text = c.Tel;
            txt_MobilePhone.Text = c.MobilePhone;
            txt_HomeName.Text = c.HomeName;
            txt_Address.Text = c.Address;
            txt_IDCard.Text = c.IDCard;
            txt_CardNo.Text = c.CardNo;
            txt_UsedHour.Text = c.UsedHour.ToString();
            txt_LeftHour.Text = c.LeftHour.ToString();
            cb_IsReg.Checked = c.IsReg.ToBoolean();

        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "14";
            base.OnInit(e);
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        public override void OnEdit()
        {

            
            DataSysDataContext dsd = new DataSysDataContext();
            int id = WS.RequestInt("id");

            ZCustomer c = new ZCustomer();
            var l = from cus in dsd.ZCustomer where cus.Id == id select cus;
            if (l.Count()>0)
            {
                c = l.First();
            }
            

            c.UserName = txt_UserName.Text.TrimDbDangerousChar();
            c.Sex = rbl_Sex.SelectedValue;
            c.Tel = txt_Tel.Text.TrimDbDangerousChar();
            c.MobilePhone = txt_MobilePhone.Text.TrimDbDangerousChar();
            c.HomeName = txt_HomeName.Text.TrimDbDangerousChar();
            c.Address = txt_Address.Text.TrimDbDangerousChar();
            c.IDCard = txt_IDCard.Text.TrimDbDangerousChar();
            c.CardNo = txt_CardNo.Text.TrimDbDangerousChar();
            c.LeftHour = txt_LeftHour.Text.ToInt32();
            c.UsedHour = txt_UsedHour.Text.ToInt32();
            c.IsReg = cb_IsReg.Checked;
            
            if (id>0)
            {
                this.IsAdd = "false";
            }
            else
            {
                this.IsAdd = "true";
                dsd.ZCustomer.InsertOnSubmit(c);
            }
            dsd.SubmitChanges();
            base.OnEdit();
            Js.AlertAndChangUrl("保存成功！", "CustomerList.aspx");
        }


    }
}
