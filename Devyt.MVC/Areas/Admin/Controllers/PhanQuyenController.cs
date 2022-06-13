using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.Admin.Controllers
{
    public class PhanQuyenController : Controller
    {
        private Admin_PhanQuyenRepository db = new Admin_PhanQuyenRepository();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetPhanQuyen()
        {
            List<Admin_PhanQuyen> hdList = (await db.GetAll()).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new Admin_PhanQuyen());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(Admin_PhanQuyen con)
        {
            if (con.Id == 0)
            {
                ResultModel<Admin_PhanQuyen> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo phân quyền thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<Admin_PhanQuyen> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật phân quyền thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa phân quyền thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa phân quyền thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}