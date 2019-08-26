﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LJD.Simple.Util
{
    /// <summary>
    /// 数据库所有表的信息
    /// </summary>
    public class DbTableInfo
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表描述说明
        /// </summary>
        public string Description
        {
            get
            {
                return string.IsNullOrEmpty(_description) ? TableName : _description;
            }
            set
            {
                _description = value;
            }
        }

        private string _description { get; set; }
    }
}
