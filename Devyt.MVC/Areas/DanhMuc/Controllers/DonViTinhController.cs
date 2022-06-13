using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class DonViTinhController : Controller
    {
        private DanhMuc_DonViTinhRepository db = new DanhMuc_DonViTinhRepository();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetDonViTinh()
        {
            List<DanhMuc_DonViTinh> hdList = (await db.GetAll()).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_DonViTinh());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_DonViTinh con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_DonViTinh> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo đơn vị tính thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_DonViTinh> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật đơn vị tính thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa đơn vị tính thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa đơn vị tính thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}