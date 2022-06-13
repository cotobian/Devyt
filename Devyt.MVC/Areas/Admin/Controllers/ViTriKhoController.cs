using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.Admin.Controllers
{
    public class ViTriKhoController : Controller
    {
        private Admin_ViTriKhoRepository db = new Admin_ViTriKhoRepository();
        private Admin_KhoRepository kdb = new Admin_KhoRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetViTriKho()
        {
            List<Admin_GetAllViTriKho_Result> hdList = db.GetAllViTriKho().ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            ViewBag.KhoList = (await kdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenKho });
            if (id == 0) return View(new Admin_ViTriKho());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(Admin_ViTriKho con)
        {
            if (con.Id == 0)
            {
                ResultModel<Admin_ViTriKho> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo vị trí kho thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<Admin_ViTriKho> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật vị trí kho thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa vị trí kho thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa vị trí kho thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}