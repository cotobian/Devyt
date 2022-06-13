using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.VanTai.Controllers
{
    public class LenhVanChuyenController : Controller
    {
        private readonly VanTai_LenhVanChuyenRepository db = new VanTai_LenhVanChuyenRepository();
        private readonly DanhMuc_DonViTinhRepository dvtdb = new DanhMuc_DonViTinhRepository();

        // GET: VanTai/LenhVanChuyen
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLenhVanChuyenTheoKeHoach(int kehoachid)
        {
            List<VanTai_GetLenhVanChuyenTheoKeHoach_Result> hdList = db.GetLenhVanChuyenTheoKeHoach(kehoachid).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id)
        {
            VanTai_LenhVanChuyen val = new VanTai_LenhVanChuyen();
            val.KeHoachVanTaiId = id;
            val.ChiNhanhId = int.Parse(Session["ChiNhanhId"].ToString());
            ViewBag.DonViTinhList = (await dvtdb.GetAll()).ResultObj;
            return View(val);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(VanTai_LenhVanChuyen con, int soluong)
        {
            if ((await db.AddBatch(con,soluong)).isSuccessed) return Json(new { success = true, message = "Tạo lệnh vận tải thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Tạo lệnh vận tải thất bại" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa lệnh vận tải thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa lệnh vận tải thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}