using System;
using System.Collections.Generic;
using System.Text;

namespace LJD.Simple.Model
{
    public class WXUserInfo
    {
        /// <summary>
        /// openId
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string avatarUrl { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 性别 1男 2女
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }
    }
}
