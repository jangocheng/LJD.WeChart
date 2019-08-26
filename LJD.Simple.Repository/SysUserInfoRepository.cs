using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using LJD.Simple.Model;
using LJD.Simple.Util;
using MySql.Data.MySqlClient;

namespace LJD.Simple.Repository
{
    public class SysUserInfoRepository
    {
        public ResponseResult GetUserInfoByInfo(string loginInfoULoginName, string loginInfoULoginPwd)
        {
            ResponseResult responseResult = new ResponseResult(false, "登录失败！");
            try
            {
                MySqlHelper mySqlHelper = new MySqlHelper();
                string strSql = "SELECT * FROM sysuserinfo WHERE ULoginName =@ULoginName AND Status = 0";
                SysUserInfo sysUser = mySqlHelper.QueryEntity<SysUserInfo>(strSql, CommandType.Text, new MySqlParameter("@ULoginName", MySqlDbType.VarChar, 20) { Value = loginInfoULoginName });
                if (sysUser != null)
                {
                    if (sysUser.ULoginPWD.Equals(loginInfoULoginPwd.ToMD5String()))
                    {
                        responseResult.Success = true;
                        responseResult.Message = "登录成功！";
                        CurrentUserManage.Login(sysUser);
                    }
                    else
                    {
                        responseResult.Message = "密码错误";
                    }
                }
                else
                {
                    responseResult.Message = "用户名不存在或已禁用！";
                }
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }
            return responseResult;
        }
    }
}
