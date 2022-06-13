using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.NhapXuat.Controllers
{
    public class HangXuatController : Controller
    {
        private NhapXuat_HangXuatRepository db = new NhapXuat_HangXuatRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaoHangXuat(int HangNhapId)
        {
            ViewBag.HangNhapId = HangNhapId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TaoHangXuat(NhapXuat_HangXuat con)
        {
            if ((await db.Add(con)).isSuccessed)
            {
                return RedirectToAction("Index", "HangXuat");
            }
            else return Json(new { success = false, message = "Tạo hàng xuất thất bại" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHangXuat()
        {
            List<NhapXuat_GetAllHangXuatByChiNhanh_Result> hdList = db.GetAllHangXuatByChiNhanh(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new NhapXuat_HangXuat());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(NhapXuat_HangXuat con)
        {
            if (con.Id == 0)
            {
                ResultModel<NhapXuat_HangXuat> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo hàng xuất thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Tạo chi nhánh thất bại" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<NhapXuat_HangXuat> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật hàng xuất thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Cập nhật hàng xuất thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa hàng xuất thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa hàng xuất thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}