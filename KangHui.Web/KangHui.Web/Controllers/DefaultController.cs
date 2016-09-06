using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KangHui.Web.Models;

namespace KangHui.Web.Controllers
{
    public class DefaultController : Controller
    {
        AppDbContext db=new AppDbContext();

        public ActionResult Mui()
        {
            return View();
        }

        public ActionResult YueBaoIndex2()
        {
            IQueryable<YueBao> data = db.YueBao;
            return View(data.ToList());
        }

        public ActionResult YueBaoIndex()
        {
            IQueryable<YueBao> list = db.YueBao;
            var data = from y in list
                       select new YueBao
                       {
                           日期 = y.日期,
                           销售量 = y.销售量,
                           销售额 = y.销售额,
                           同比 = y.同比,
                           环比 = y.环比,
                       };
            return View(list.ToList());
        }

        public ActionResult YueBaoItem(string viewtype)
        {
            IQueryable<YueBao> list = db.YueBao;
            if (viewtype == "kehu")
            {
                return PartialView("YueBaoKeHu", list.ToList());
            }
            else if (viewtype == "yewuyuan")
            {
                return PartialView("YueBaoYeWuYuan", list.ToList());
            }
            else if (viewtype == "chanpin")
            {
                return PartialView("YueBaoChanPin", list.ToList());
            }
            else
            {
                return PartialView("YueBaoRiQi", list.ToList());
            }

        }

        public ActionResult JianBaoIndex(DateTime? start,DateTime? end)
        {
            IQueryable<JianBao> list = db.JianBao.OrderByDescending(x=>x.Id);
            if (start.HasValue)
            {
                list = list.Where(x => x.RiQi >= start.Value);
            }
            if (end.HasValue)
            {
                var enddate = end.Value.AddDays(1);
                list = list.Where(x => x.RiQi < enddate);
            }

            var data = list.ToList();
            if (Request.IsAjaxRequest())
            {
                
                return PartialView("JianBaoItems", data);
            }
            return View(data);
        }


        public ActionResult KuCunIndex(string goods)
        {

            var storeQuery = from d in db.KuCun select  d ;
            ViewBag.goodslist = new SelectList(storeQuery.Distinct(), "产品", "产品");

            IQueryable<KuCun> list = db.KuCun.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(goods))
            {
                list = list.Where(x => x.产品== goods);
            }
          
            var data = list.ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("KuCunItems", data);
            }
            return View(data);
        }



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}