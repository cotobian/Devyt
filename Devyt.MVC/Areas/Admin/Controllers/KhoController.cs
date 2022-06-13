using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.Admin.Controllers
{
    public class KhoController : Controller
    {
        private Admin_KhoRepository db = new Admin_KhoRepository();
        private Admin_ChiNhanhRepository cndb = new Admin_ChiNhanhRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetKho()
        {
            List<Admin_GetAllKho_Result> hdList = db.GetAllKho().ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            ViewBag.ChiNhanhList = (await cndb.GetAll()).ResultObj.Select(c => new { c.Id, c.ChiNhanh });
            if (id == 0) return View(new Admin_Kho());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(Admin_Kho con)
        {
            if (con.Id == 0)
            {
                ResultModel<Admin_Kho> res = await db.Add(con);
                if(res.isSuccessed)return Json(new { success = true, message = "Tạo kho thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<Admin_Kho> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật kho thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa kho thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa kho thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}