using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KangHui.Web.Models
{
    public class JianBao
    {
        public long Id { get; set; }

        public int FangMiaoZhiShu { get; set; }
        public int HuiShouZhiShu { get; set; }
        public decimal? JiMiaoJiaGe { get; set; }
        public decimal? HuiShouJiaGe { get; set; }
    }
}