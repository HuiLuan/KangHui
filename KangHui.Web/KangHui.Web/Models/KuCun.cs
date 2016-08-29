using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KangHui.Web.Models
{
    public class KuCun
    {
        public long Id { get; set; }
        public string 产品 { get; set; }
        public string 库存 { get; set; }
        public string 订货 { get; set; }
        public string 采购 { get; set; }
        public string 差异 { get; set; }
    }
}