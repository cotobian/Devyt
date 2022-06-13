using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class DiaDiemController : Controller
    {
        private DanhMuc_DiaDiemRepository db = new DanhMuc_DiaDiemRepository();

        // GET: DanhMuc/DiaDiem
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetDiaDiem()
        {
            List<DanhMuc_DiaDiem> hdList = (await db.GetAll()).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_DiaDiem());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_DiaDiem con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_DiaDiem> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo địa điểm thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_DiaDiem> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật địa điểm thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa địa điểm thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa địa điểm thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}