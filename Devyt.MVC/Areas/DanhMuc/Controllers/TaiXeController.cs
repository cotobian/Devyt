using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class TaiXeController : Controller
    {
        private DanhMuc_TaiXeRepository db = new DanhMuc_TaiXeRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTaiXe()
        {
            List<DanhMuc_GetAllTaiXeByChiNhanh_Result> hdList = db.GetAllTaiXe(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_TaiXe());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_TaiXe con)
        {
            if (con.Id == 0)
            {
                con.ChiNhanhId = int.Parse(Session["ChiNhanhId"].ToString());
                ResultModel<DanhMuc_TaiXe> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo tài xế thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_TaiXe> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật tài xế thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa tài xế thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa tài xế thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}