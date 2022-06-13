using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Repositories;
using Devyt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Devyt.MVC.Areas.VanTai.Controllers
{
    public class ChuyenDieuVanController : Controller
    {
        private VanTai_ChuyenDieuVanRepository db = new VanTai_ChuyenDieuVanRepository();
        private VanTai_LenhVanChuyenRepository vcdb = new VanTai_LenhVanChuyenRepository();
        private DanhMuc_XeVanTaiRepository xedb = new DanhMuc_XeVanTaiRepository();
        private DanhMuc_TaiXeRepository txdb = new DanhMuc_TaiXeRepository();
        private DanhMuc_DonViVanTaiRepository dvtdb = new DanhMuc_DonViVanTaiRepository();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> TaoChuyenMoi()
        {
            ViewBag.XeVanTaiList = (await xedb.GetAll()).ResultObj.Select(c => new { c.Id, c.SoXe });
            ViewBag.TaiXeList = (await txdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenLaiXe });
            ViewBag.DonViVanTaiList = (await dvtdb.GetAll()).ResultObj.Select(c => new { c.Id, c.TenDonViVanTai });
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TaoChuyenMoi(VanTai_ChuyenDieuVan con, int? id1, int? id2)
        {
            if(id1 == null) return Json(new { success = false, message = "Lệnh vận chuyển không thể để trống!" }, JsonRequestBehavior.AllowGet);
            con.ChiNhanhId = int.Parse(Session["ChiNhanhId"].ToString());
            ResultModel<VanTai_ChuyenDieuVan> res = (await db.Add(con));
            if (res.isSuccessed)
            {
                await db.UpdateChuyenXe((int)id1, res.ResultObj.Id);
                if (id2 != null) await db.UpdateChuyenXe((int)id2, res.ResultObj.Id);
                return Json(new { success = true, message = "Tạo chuyến thành công" }, JsonRequestBehavior.AllowGet);
            }
            else return Json(new { success = false, message = res.Message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChuyenDieuVan()
        {
            List<VanTai_GetAllChuyenDieuVanTheoChiNhanh_Result> hdList = db.GetAllChuyenDieuVanTheoChiNhanh(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj;
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLenhVanChuyenKhoiTao()
        {
            List<VanTai_GetAllChuyenDieuVanTheoChiNhanh_Result> hdList = db.GetAllChuyenDieuVanTheoChiNhanh(int.Parse(Session["ChiNhanhId"].ToString())).ResultObj.Where(c => c.TrangThai == 0).ToList();
            return Json(new { data = hdList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0) return View(new VanTai_ChuyenDieuVan());
            else
            {
                return View(db.GetById(id).ResultObj);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(VanTai_ChuyenDieuVan con)
        {
            if (con.Id == 0)
            {
                if ((await db.Add(con)).isSuccessed) return Json(new { success = true, message = "Tạo chuyến thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Tạo chuyến thất bại" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if ((await db.Update(con)).isSuccessed) return Json(new { success = true, message = "Cập nhật chuyến thành công" }, JsonRequestBehavior.AllowGet);
                else return Json(new { success = false, message = "Cập nhật chuyến thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }

        //delete
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await db.Delete(id)).isSuccessed) return Json(new { success = true, message = "Xóa chuyến thành công" }, JsonRequestBehavior.AllowGet);
            else return Json(new { success = false, message = "Xóa chuyến thất bại" }, JsonRequestBehavior.AllowGet);
        }
    }
}