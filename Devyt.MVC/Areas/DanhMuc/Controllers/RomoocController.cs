using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class RomoocController : Controller
    {
        private DanhMuc_RomoocRepository db = new DanhMuc_RomoocRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRomooc()
        {
            List<DanhMuc_GetAllRoMooc_Result> hdList = db.GetAllRoMooc().ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_Romooc());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_Romooc con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_Romooc> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo Rơ mooc thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_Romooc> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật Rơ mooc thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa Rơ mooc thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa Rơ mooc thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}