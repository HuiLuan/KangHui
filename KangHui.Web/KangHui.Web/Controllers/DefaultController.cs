using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KangHui.Web.Controllers
{
    public class DefaultController : Controller
    {
        AppDbContext db=new AppDbContext();
        public ActionResult JianBaoIndex()
        {
            return View();
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