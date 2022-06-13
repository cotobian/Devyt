using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.Report.Controllers
{
    public class BaoCaoVanTaiController : Controller
    {
        // GET: Report/BaoCaoVanTai
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BaoCaoVanChuyen()
        {
            return View();
        }

        public ActionResult BaoCaoTaiXe()
        {
            return View();
        }
    }
}