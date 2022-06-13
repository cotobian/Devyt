using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.Report.Controllers
{
    public class BaoCaoKhoController : Controller
    {
        private Report_BaoCaoKhoRepository db = new Report_BaoCaoKhoRepository();
        // GET: Report/BaoCaoKho
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BaoCaoTonKho()
        {
            return View();
        }

        public JsonResult TonKho()
        {
            List<Report_BaoCaoTonKho_Result> list = db.GetBaoCaoTonKho(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BaoCaoNhapXuat()
        {
            return View();
        }

        public JsonResult NhapXuat()
        {
            List<Report_BaoCaoTonKho_Result> list = db.GetBaoCaoTonKho(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
    }
}