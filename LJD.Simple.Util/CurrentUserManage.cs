using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using LJD.Simple.Model;
using LJD.Simple.Util;
using Microsoft.AspNetCore.Http;

namespace LJD.Simple.Util
{
    /// <summary>
    /// 用户相关信息
    /// </summary>
    public static class CurrentUserManage
    {
        /// <summary>
        /// 当前登陆用户
        /// </summary>
        public static SysUserInfo UserInfo
        {
            get
            {
                //如果是测试模式 就直接是返回某个数据
                if (GlobalSwitch.RunModel == RunModel.LocalTest)
                {
                    SysUserInfo userInfo  = new SysUserInfo()
                    {
                        ObjectID = "002C25CA-AB09-451B-864C-65AD3C9A0F58",
                        ULoginName = "admin",
                        URealName = "系统管理员"
                    };
                    return userInfo;
                }
                else
                {
                    //获取客户端Cookies
                    var userLoginId = HttpContextCore.Current.Request.Cookies[APPKeys.CurrentUser];
                    //如果客户端Cookies不为null
                    if (!string.IsNullOrEmpty(userLoginId))
                    {
                        return CacheHelper.Cache.GetCache<SysUserInfo>(userLoginId);
                    }

                    return null;
                }
            }
        } 

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            return UserInfo != null;
        }

        public static bool IsAdministrator()
        {
            return UserInfo.ULoginName.Equals("admin");
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userInfo"></param>
        public static void Login(SysUserInfo userInfo)
        {
            string userLoginId = Guid.NewGuid().ToString();
            //往客户端写入Cookie
            HttpContextCore.Current.Response.Cookies.Append(APPKeys.CurrentUser, userLoginId, new CookieOptions() { HttpOnly = true }); 
            //把登陆用户保存到缓存中
            CacheHelper.Cache.SetCache(userLoginId, userInfo, TimeSpan.FromMinutes(GlobalSwitch.LoginExpireMinutes), ExpireType.Relative);
        }

        /// <summary>
        /// 注销
        /// </summary>
        public static void Logout()
        {

            if (GlobalSwitch.RunModel != RunModel.LocalTest)
            {
                //获取客户端Cookies
                var userLoginId = HttpContextCore.Current.Request.Cookies[APPKeys.CurrentUser];
                //清空缓存
                CacheHelper.Cache.RemoveCache(userLoginId);
                //清空客户端Cookies
                HttpContextCore.Current.Response.Cookies.Delete(APPKeys.CurrentUser);
            }

        }

    }
}
