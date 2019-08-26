using System;
using System.Collections.Generic;
using System.Text;

namespace LJD.Simple.Util.Model
{
    public class PagerInfo
    {
        /// <summary>
        /// 页码的参数名称
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页数据量的参数名
        /// </summary>
        public int limit { get; set; }
    }
}
