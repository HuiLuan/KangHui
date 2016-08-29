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

        public ActionResult JianBaoIndex(DateTime? start,DateTime? end)
        {
            IQueryable<JianBao> list = db.JianBao.OrderByDescending(x=>x.Id);
            if (start.HasValue)
            {
                list = list.Where(x => x.RiQi >= start.Value);
            }
            if (end.HasValue)
            {
                list = list.Where(x => x.RiQi < end.Value.AddDays(1));
            }

            var data = list.ToList();
            if (Request.IsAjaxRequest())
            {
                
                return PartialView("JianBaoItems", list.Skip(1).Take(1).ToList());
            }
            return View(data);
        }


        public ActionResult KuCunIndex(string chanpin)
        {
            IQueryable<KuCun> list = db.KuCun.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(chanpin))
            {
                list = list.Where(x => x.产品==chanpin);
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