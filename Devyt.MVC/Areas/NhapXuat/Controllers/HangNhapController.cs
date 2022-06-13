using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.NhapXuat.Controllers
{
    public class HangNhapController : Controller
    {
        private NhapXuat_HangNhapRepository db = new NhapXuat_HangNhapRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaoHangNhap(int LoHangId)
        {
            ViewBag.LoHangId = LoHangId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TaoHangNhap(NhapXuat_HangNhap con)
        {
            if ((await db.Add(con)).isSuccessed)
            {
                return RedirectToAction("Index", "HangNhap");
            }
            else return Json(new { success = false, message = "Tạo hàng nhập thất bại" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHangNhap()
        {
            List<NhapXuat_GetAllHangNhapByChiNhanh_Result> hdList = db.GetAllHangNhapByChiNhanh(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new NhapXuat_HangNhap());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(NhapXuat_HangNhap con)
        {
            if (con.Id == 0)
            {
                if ((await db.Add(con)).isSuccessed) return Json(new { success = true, message = "Tạo hàng nhập thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Tạo hàng nhập thất bại" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if ((await db.Update(con)).isSuccessed) return Json(new { success = true, message = "Cập nhật hàng nhập thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Cập nhật hàng nhập thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa hàng nhập thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa hàng nhập thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}