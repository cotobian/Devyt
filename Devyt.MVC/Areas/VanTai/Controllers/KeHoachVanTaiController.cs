using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.VanTai.Controllers
{
    public class KeHoachVanTaiController : Controller
    {
        private VanTai_KeHoachVanTaiRepository db = new VanTai_KeHoachVanTaiRepository();
        private DanhMuc_DiaDiemRepository dddb = new DanhMuc_DiaDiemRepository();
        private DanhMuc_LoaiHangRepository lhdb = new DanhMuc_LoaiHangRepository();
        private DanhMuc_DonViVanTaiRepository vtdb = new DanhMuc_DonViVanTaiRepository();
        private DanhMuc_KhachHangRepository khdb = new DanhMuc_KhachHangRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllKeHoachVanTai()
        {
            List<VanTai_GetAllKeHoachVanTaiTheoChiNhanh_Result> hdList = db.GetAllKeHoachVanTaiTheoChiNhanh(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> TaoKeHoachVanTai()
        {
            ViewBag.DiaDiemList = (await dddb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenDiaDiem });
            ViewBag.LoaiHangList = (await lhdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenLoaiHang });
            ViewBag.DonViVanTaiList = (await vtdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenDonViVanTai });
            ViewBag.KhachHangList = (await khdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenKhachHang });
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TaoKeHoachVanTai(VanTai_KeHoachVanTai con)
        {
            con.NgayTao = DateTime.Now;
            con.ChiNhanhId = int.Parse(Session["ChiNhanhId"].ToString());
            con.TrangThai = 0;
            ResultModel<VanTai_KeHoachVanTai> res = await db.Add(con);
            if (res.isSuccessed)
            {
                return RedirectToAction("Index", "LenhVanChuyen", new { KeHoachVanTaiId = con.Id });
            }
            else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new VanTai_KeHoachVanTai());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(VanTai_KeHoachVanTai con)
        {
            if (con.Id == 0)
            {
                if ((await db.Add(con)).isSuccessed) return Json(new { success = true, message = "Tạo kế hoạch vận tải thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Tạo kế hoạch vận tải thất bại" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if ((await db.Update(con)).isSuccessed) return Json(new { success = true, message = "Cập nhật kế hoạch vận tải thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Cập nhật kế hoạch vận tải thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa kế hoạch vận tải thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa kế hoạch vận tải thất bại" }, JsonRequestBehavior.AllowGet);
        }

    }
}