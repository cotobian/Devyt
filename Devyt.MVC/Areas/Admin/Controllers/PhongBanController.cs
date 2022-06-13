using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.Admin.Controllers
{
    public class PhongBanController : Controller
    {
        private Admin_PhongBanRepository db = new Admin_PhongBanRepository();
        private Admin_ChiNhanhRepository cndb = new Admin_ChiNhanhRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPhongBan()
        {
            List<Admin_GetAllPhongBan_Result> hdList = db.GetAllPhongBan().ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            ViewBag.ChiNhanhList = (await cndb.GetAll()).ResultObj.Select(c => new { c.Id, c.ChiNhanh });
            if (id == 0) return View(new Admin_PhongBan());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(Admin_PhongBan con)
        {
            if (con.Id == 0)
            {
                ResultModel<Admin_PhongBan> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo phòng ban thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<Admin_PhongBan> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật phòng ban thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa phòng ban thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa phòng ban thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}