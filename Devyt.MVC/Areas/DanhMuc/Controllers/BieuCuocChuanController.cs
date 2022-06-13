using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class BieuCuocChuanController : Controller
    {
        private DanhMuc_BieuCuocChuanRepository db = new DanhMuc_BieuCuocChuanRepository();
        private DanhMuc_DonViTinhRepository dvtdb = new DanhMuc_DonViTinhRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBieuCuocChuan()
        {
            List<DanhMuc_GetAllBieuCuocChuan_Result> hdList = db.GetAllBieuCuocChuan().ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            ViewBag.DonViTinhList = (await dvtdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenDonViTinh });
            if (id == 0) return View(new DanhMuc_BieuCuocChuan());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_BieuCuocChuan con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_BieuCuocChuan> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo biểu cước thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_BieuCuocChuan> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật biểu cước thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa biểu cước thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa biểu cước thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}