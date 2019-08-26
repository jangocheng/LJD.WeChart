using System;
using System.Collections.Generic;

namespace LJD.Simple.Model
{
    public partial class SysUserInfo
    { 
        public string ObjectID { get; set; }
        public string ULoginName { get; set; }
        public string ULoginPWD { get; set; }
        public string URealName { get; set; }
        public string UTelphone { get; set; }
        public string UMobile { get; set; }
        public string UEmail { get; set; }
        public string UQQ { get; set; }
        public int? UGender { get; set; }
        public string UDepID { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Sort { get; set; } 
    }
}
