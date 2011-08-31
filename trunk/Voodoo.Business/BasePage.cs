using System;
using System.Linq;
using System.Web;

using Voodoo.Security;

namespace Voodoo.Business
{
    public class BasePage : System.Web.UI.Page
    {
        #region 参数
        /// <summary>
        /// 页面的菜单ID
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// 是否是新增数据
        /// </summary>
        public string  IsAdd { get; set; }

        protected string cookie_key = "挨地嘛";
        #endregion



        #region 事件重写方法 所有的编辑事件都应该重写此方法
        /// <summary>
        /// 编辑事件 所有的编辑事件都应该重写此方法
        /// </summary>
        public virtual void OnEdit()
        {
            if (IsAdd==null)
            {
                ThrowError("请在保存数据的代码前设置参数IsAdd=\"true\"; 或IsAdd=\"false\";");
                return;
            }
            if (SysPartRole.AllowEdit == false && IsAdd.ToBoolean()==false)
            {
                ThrowError("当前用户禁止编辑本模块数据");
            }
            if (SysPartRole.AllowAdd == false && IsAdd.ToBoolean() == true)
            {
                ThrowError("当前用户禁止创建本模块数据");
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        public virtual void OnDelete()
        {
            if (SysPartRole.AllowDelete == false)
            {
                ThrowError("当前用户禁止删除本模块数据");
            }
        }

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (MenuId == null)
            {
                this.MenuId = "0";
            }

            if (SysPartRole.AllowView == false)
            {
                ThrowError("禁止访问");
            }
            

        }

        /// <summary>
        /// 系统权限
        /// </summary>
        protected GroupMenuRelation SysPartRole
        {
            get
            {
                //超级管理员不需要验证
                if (this.Opuser.GroupId==4)
                {
                    GroupMenuRelation superRole = new GroupMenuRelation();
                    superRole.AllowAdd = true;
                    superRole.AllowDelete = true;
                    superRole.AllowEdit = true;
                    superRole.AllowView = true;
                    return superRole;
                }

                DataSysDataContext dsd = new DataSysDataContext();

                var roles = from role in dsd.GroupMenuRelation where role.GroupId == this.Opuser.GroupId && role.SysPartId == this.MenuId.ToInt32() select role;
                if (roles.Count() == 0)
                {
                    ThrowError("请配置系统模块和权限！<ul><li>在页面的Onit事件中设置MenuId</li></ul> <ul><li>SysPart表中要存在本页面的记录</li></ul> <ul><li>GroupMenuRelation要有群组的权限配置</li></ul>");
                    return new GroupMenuRelation();
                }
                else
                {
                    //权限配置
                    return roles.First();

                }
            }
        }

        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">帐号</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public Result UserLogin(string UserName, string Password)
        {
            DataSysDataContext dsd = new DataSysDataContext();

            Result result = new Result();

            string Md5Pass = Encrypt.Md5(Password);

            var user = from u in dsd.User
                       where u.UserName == UserName.TrimDbDangerousChar() && u.UserPassword == Md5Pass
                       select u;
            if (user.Count() > 0)
            {
                User u = user.First();
                if (u.Status == e_UserStatus.停用.ToString())
                {
                    result.Success = false;
                    result.Text = "对不起，您的帐号已经停用，如有疑问，请联系管理员！";
                }
                else
                {
                    result.Success = true;
                    result.Text = "恭喜，登录成功！";

                    //登录成功，开始写入Cookie 
                    HttpCookie cookie = new HttpCookie("userinfo");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    cookie.Values.Add("id", u.Id.ToString());
                    cookie.Values.Add("username", u.UserName);
                    cookie.Values.Add("k", Encrypt.md5_3(u.Id + u.UserName + u.UserPassword + cookie_key));
                    Voodoo.Cookies.Cookies.SetCookie(cookie);
                }
            }
            else
            {
                result.Success = false;
                result.Text = "对不起，您输入的帐号或密码错误，请重新输入";
            }

            return result;
        }
        #endregion

        #region 当前登录用户
        /// <summary>
        /// 当前登录用户
        /// </summary>
        protected User Opuser
        {
            get
            {
                User user = new User();

                user.Id = 1;
                user.Sex = "男";
                user.Status = "正常";
                user.UserName = "Admin";
                user.GroupId = 1;
                return user;

                HttpCookie cookie = Voodoo.Cookies.Cookies.GetCookie("userinfo");
                if (cookie == null)
                {
                    //找不到Cookie
                    user.Id = int.MinValue;
                    user.GroupId = 3;
                    return user;
                }
                else
                {
                    DataSysDataContext dsd = new DataSysDataContext();

                    int userId = cookie.Values["id"].ToInt32();
                    string userName = cookie.Values["username"];
                    string key = cookie.Values["k"];

                    user = (from u in dsd.User where u.Id == userId select u).First();

                    if (Encrypt.md5_3(user.Id + user.UserName + user.UserPassword + cookie_key) == key)
                    {
                        //Cookie Key验证通过
                        return user;
                    }
                    else
                    {
                        user.Id = int.MinValue;
                        user.GroupId = 3;
                        return user;
                    }
                }
            }
        }
        #endregion

        #region 抛出页面异常
        /// <summary>
        /// 抛出页面异常
        /// </summary>
        /// <param name="msg"></param>
        protected void ThrowError(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
        #endregion

    }
}
