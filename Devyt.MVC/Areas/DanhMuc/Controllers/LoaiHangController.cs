using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class LoaiHangController : Controller
    {
        private DanhMuc_LoaiHangRepository db = new DanhMuc_LoaiHangRepository();
        // GET: DanhMuc/LoaiHang
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetLoaiHang()
        {
            List<DanhMuc_LoaiHang> hdList = (await db.GetAll()).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_LoaiHang());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_LoaiHang con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_LoaiHang> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo loại hàng thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_LoaiHang> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật loại hàng thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa loại hàng thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa loại hàng thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}