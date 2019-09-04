using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LJD.Simple.Model;
using Microsoft.AspNetCore.Mvc;

namespace LJD.WeChart.Controllers
{
    public class WeChartController : Controller
    {
        [HttpPost]
        public IActionResult Login(string openId)
        {
            ResponseResult responseResult=new ResponseResult(false);

            try
            {
                var strSql = $"insert into loginlog(time,openId)VALUES(NOW(),'{openId}')";
                var count = new MySqlHelper().ExecuteNonQuery(strSql, CommandType.Text);
                if (count != 1)
                {
                    throw new Exception("失败");
                }
                else
                {
                    strSql = $"SELECT sum(Amount) from tallydetailinfo WHERE User='{openId}'";
                    var amount = new MySqlHelper().ExecuteScalar(strSql, CommandType.Text).ToString();
                    responseResult.Success = true;
                    responseResult.Message = $"累计消费：【{amount}】";
                }
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult);
        }


        [HttpPost]
        public IActionResult Tally(TallyInfo tallyInfo)
        {
            ResponseResult responseResult = new ResponseResult(false);

            try
            {
                if (string.IsNullOrEmpty(tallyInfo.User))
                {
                    throw new Exception("没有登陆信息！");
                }
                if (string.IsNullOrEmpty(tallyInfo.ExpenseTime))
                {
                    throw new Exception("请选择消费时间！");
                }
                if (string.IsNullOrEmpty(tallyInfo.TallyType))
                {
                    throw new Exception("请选择消费类型！");
                }
                if (tallyInfo.Amount.Equals(0))
                {
                    throw new Exception("请输入消费金额！");
                }

                var strSql = $"INSERT into tallydetailinfo(User,TallyType,ExpenseTime,CreatedTime,Amount,Remarks)  VALUES('{tallyInfo.User}','{tallyInfo.TallyType}','{tallyInfo.ExpenseTime}',NOW(),'{tallyInfo.Amount}','{tallyInfo.Remarks}')";
                var count = new MySqlHelper().ExecuteNonQuery(strSql, CommandType.Text);
                if (count != 1)
                {
                    throw new Exception("记录成功!");
                }
                else
                {
                    responseResult.Success = true;
                    responseResult.Message = "记录成功!";
                }
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult); 
        }
    }
}