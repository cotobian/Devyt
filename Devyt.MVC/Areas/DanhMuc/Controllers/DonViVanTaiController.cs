using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class DonViVanTaiController : Controller
    {
        private readonly DanhMuc_DonViVanTaiRepository db = new DanhMuc_DonViVanTaiRepository(); 
        // GET: DanhMuc/DonViVanTai
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetDonViVanTai()
        {
            List<DanhMuc_DonViVanTai> List = (await db.GetAll()).ResultObj;
            return Json(new { data = List }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_DonViVanTai());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_DonViVanTai con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_DonViVanTai> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo đơn vị vận tải thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_DonViVanTai> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật đơn vị vận tải thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa đơn vị vận tải thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa đơn vị vận tải thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}