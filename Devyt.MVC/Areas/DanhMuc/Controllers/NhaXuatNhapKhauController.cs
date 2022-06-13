using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.DanhMuc.Controllers
{
    public class NhaXuatNhapKhauController : Controller
    {
        private DanhMuc_NhaXuatNhapKhauRepository db = new DanhMuc_NhaXuatNhapKhauRepository();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetNhaXuatNhapKhau()
        {
            List<DanhMuc_NhaXuatNhapKhau> hdList = (await db.GetAll()).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new DanhMuc_NhaXuatNhapKhau());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(DanhMuc_NhaXuatNhapKhau con)
        {
            if (con.Id == 0)
            {
                ResultModel<DanhMuc_NhaXuatNhapKhau> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo nhà XNK thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<DanhMuc_NhaXuatNhapKhau> res = await db.Update(con);
                if ((await db.Update(con)).isSuccessed) return Json(new { success = true, message = "Cập nhật nhà XNK thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa nhà XNK thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa nhà XNK thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}