using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        private Admin_TaiKhoanRepository db = new Admin_TaiKhoanRepository();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetTaiKhoan()
        {
            List<Admin_TaiKhoan> hdList = (await db.GetAll()).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new Admin_TaiKhoan());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(Admin_TaiKhoan con)
        {
            if (con.Id == 0)
            {
                if ((await db.Add(con)).isSuccessed) return Json(new { success = true, message = "Tạo chi nhánh thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Tạo chi nhánh thất bại" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if ((await db.Update(con)).isSuccessed) return Json(new { success = true, message = "Cập nhật chi nhánh thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Cập nhật chi nhánh thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa chi nhánh thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa chi nhánh thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}