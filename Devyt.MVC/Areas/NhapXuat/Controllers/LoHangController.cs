using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.NhapXuat.Controllers
{
    public class LoHangController : Controller
    {
        private NhapXuat_LoHangRepository db = new NhapXuat_LoHangRepository();
        private Admin_KhoRepository kdb = new Admin_KhoRepository();
        private DanhMuc_NhaXuatNhapKhauRepository xnkdb = new DanhMuc_NhaXuatNhapKhauRepository();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> TaoLoHang()
        {
            ViewBag.KhoList = (await kdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenKho });
            ViewBag.NhaXNKList = (await xnkdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenNhaXNK });
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TaoLoHang(NhapXuat_LoHang lh)
        {
            ResultModel<NhapXuat_LoHang> res = await db.Add(lh);
            if (res.isSuccessed)
            {
                return RedirectToAction("TaoHangNhap", "HangNhap", new { LoHangId = res.ResultObj.Id });
            }
            else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLoHang()
        {
            List<NhapXuat_GetAllLoHangByChiNhanh_Result> hdList = db.GetAllLoHangByChiNhanh(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new NhapXuat_LoHang());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(NhapXuat_LoHang con)
        {
            if (con.Id == 0)
            {
                ResultModel<NhapXuat_LoHang> res = await db.Add(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Tạo lô hàng thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ResultModel<NhapXuat_LoHang> res = await db.Update(con);
                if (res.isSuccessed) return Json(new { success = true, message = "Cập nhật lô hàng thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa lô hàng thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa lô hàng thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}