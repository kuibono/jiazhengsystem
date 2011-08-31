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
    public partial class RoleEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialRalation();
                BindData();
            }
        }

        protected void InitialRalation()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            var allRelation = from g in dsd.Group
                              join s in dsd.SysPart
                              on 1 equals 1
                              select new { GroupId = g.Id, SyspartId = s.Id };

            foreach (var r in allRelation)
            {
                var relation = from ra in dsd.GroupMenuRelation where ra.GroupId == r.GroupId && ra.SysPartId == r.SyspartId select ra;
                if (relation.Count()==0)
                {
                    GroupMenuRelation gmr = new GroupMenuRelation();
                    gmr.GroupId = r.GroupId;
                    gmr.SysPartId = r.SyspartId;
                    gmr.AllowView = false;
                    gmr.AllowEdit = false;
                    gmr.AllowDelete = false;
                    gmr.AllowAdd = false;

                    dsd.GroupMenuRelation.InsertOnSubmit(gmr);
                    dsd.SubmitChanges();
                }
            }
        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void BindData()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            int groupId = WS.RequestInt("groupid");
            int syspartId = WS.RequestInt("syspartid");

            if (groupId > 0)
            {
                var gmr = from gr in dsd.GroupMenuRelation
                          from sp in dsd.SysPart
                          from g in dsd.Group
                          where gr.GroupId == g.Id && gr.SysPartId == sp.Id && gr.GroupId == groupId
                          select new
                          {
                              GroupId = gr.GroupId,
                              GroupName = g.Name,
                              syspartId = sp.Id,
                              SyspartName = sp.MenuTitle,
                              gr.AllowView,
                              gr.AllowAdd,
                              gr.AllowDelete,
                              gr.AllowEdit
                          };
                list.DataSource = gmr;
                list.DataBind();

                for (int i = 0; i < list.Items.Count; i++)
                {
                    ((CheckBox)list.Items[i].FindControl("chk_View")).Checked = gmr.ToList()[i].AllowView.ToBoolean();
                    ((CheckBox)list.Items[i].FindControl("chk_Del")).Checked = gmr.ToList()[i].AllowDelete.ToBoolean();
                    ((CheckBox)list.Items[i].FindControl("chk_Edit")).Checked = gmr.ToList()[i].AllowEdit.ToBoolean();
                    ((CheckBox)list.Items[i].FindControl("chk_Add")).Checked = gmr.ToList()[i].AllowAdd.ToBoolean();

                }

            }
            if (syspartId > 0)
            {
                var gmr = from gr in dsd.GroupMenuRelation
                          from sp in dsd.SysPart
                          from g in dsd.Group
                          where gr.GroupId == g.Id && gr.SysPartId == sp.Id && gr.SysPartId == syspartId
                          select new
                          {
                              GroupId = gr.GroupId,
                              GroupName = g.Name,
                              syspartId = sp.Id,
                              SyspartName = sp.MenuTitle,
                              gr.AllowView,
                              gr.AllowAdd,
                              gr.AllowDelete,
                              gr.AllowEdit
                          };
                list.DataSource = gmr;
                list.DataBind();
                for (int i = 0; i < list.Items.Count; i++)
                {
                    ((CheckBox)list.Items[i].FindControl("chk_View")).Checked = gmr.ToList()[i].AllowView.ToBoolean();
                    ((CheckBox)list.Items[i].FindControl("chk_Del")).Checked = gmr.ToList()[i].AllowDelete.ToBoolean();
                    ((CheckBox)list.Items[i].FindControl("chk_Edit")).Checked = gmr.ToList()[i].AllowEdit.ToBoolean();
                    ((CheckBox)list.Items[i].FindControl("chk_Add")).Checked = gmr.ToList()[i].AllowAdd.ToBoolean();

                }
            }

        }
        #endregion

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "6";
            base.OnInit(e);
        }

        public override void OnEdit()
        {
            DataSysDataContext dsd = new DataSysDataContext();

            this.IsAdd = "fasle";
            base.OnEdit();

            int groupId = WS.RequestInt("groupid");
            int syspartId = WS.RequestInt("syspartid");
            List<GroupMenuRelation> gmr = new List<GroupMenuRelation>();
            if (groupId > 0)
            {
                gmr = (from g in dsd.GroupMenuRelation where g.GroupId == groupId select g).ToList();
            }
            if (syspartId > 0)
            {
                gmr = (from g in dsd.GroupMenuRelation where g.SysPartId == syspartId select g).ToList();
            }

            for (int i = 0; i < list.Items.Count; i++)
            {
                gmr[i].AllowView = ((CheckBox)list.Items[i].FindControl("chk_View")).Checked;
                gmr[i].AllowDelete = ((CheckBox)list.Items[i].FindControl("chk_Del")).Checked;
                gmr[i].AllowEdit = ((CheckBox)list.Items[i].FindControl("chk_Edit")).Checked;
                gmr[i].AllowAdd = ((CheckBox)list.Items[i].FindControl("chk_Add")).Checked;

            }
            dsd.SubmitChanges();
            if (groupId > 0)
            {
                Js.AlertAndChangUrl("保存成功！", "GropList.aspx");
            }
            if (syspartId > 0)
            {
                Js.AlertAndChangUrl("保存成功！", "SysPartList.aspx");
            }


        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
