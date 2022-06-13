using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class XeVanTaiController : Controller
    {
        private DanhMuc_XeVanTaiRepository db = new DanhMuc_XeVanTaiRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetXeVanTai()
        {
            List<DanhMuc_GetAllXeVanTai_Result> hdList = db.GetAllXeVanTai().ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_XeVanTai());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_XeVanTai con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_XeVanTai> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo xe vận tải thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_XeVanTai> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật xe vận tải thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa xe vận tải thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa xe vận tải thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}