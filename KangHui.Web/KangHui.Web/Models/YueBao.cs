using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KangHui.Web.Models
{
    public class YueBao
    {
        public long Id { get; set; }
        public DateTime 日期 { get; set; }
        public string 客户 { get; set; }
        public string 业务员 { get; set; }
        public string 产品 { get; set; }
        public int? 销售量 { get; set; }
        public decimal? 销售额 { get; set; }
        public string 同比 { get; set; }
        public string 环比 { get; set; }
    }
}