using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class VanTai_ChuyenDieuVanRepository : BaseRepository<VanTai_ChuyenDieuVan>
    {
        public void validateDoiTuong(VanTai_ChuyenDieuVan dv, validateMethod method)
        {
            if (dv.DonViVanTaiId == null) 
                throw new ValidateException("Đơn vị vận tải không thể để trống");
            if (dv.LenhVanChuyenId == null) 
                throw new ValidateException("Lệnh vận chuyển không thể để trống");
            if (dv.SoCont == null) 
                throw new ValidateException("Số cont không thể để trống");
            if (dv.SoCont != null && dv.SoCont.Length > 11)     
                throw new ValidateException("Số cont không thể dài hơn 11 ký tự");
            if(dv.TrongTai == null)
                throw new ValidateException("Trọng lượng cont không thể để trống");
            if (dv.TrongTai != null && dv.TrongTai.ToString().Length > 8)
                throw new ValidateException("Trọng lượng cont không thể lớn hơn 8 ký tự");
            if (dv.XeVanTaiId == null)
                throw new ValidateException("Xe vận tải không thể để trống");
            if (dv.TaiXeId == null)
                throw new ValidateException("Tài xế không thể để trống");
            if (dv.DoanhThuCuoc != null && dv.DoanhThuCuoc.ToString().Length > 18)
                throw new ValidateException("Doanh thu cước không thể lớn hơn 18 ký tự");
            if (dv.DoanhThuKhac != null && dv.DoanhThuKhac.ToString().Length > 18)
                throw new ValidateException("Doanh thu khác không thể lớn hơn 18 ký tự");
            if (dv.TongDoanhThu != null && dv.TongDoanhThu.ToString().Length > 18)
                throw new ValidateException("Tổng doanh thu không thể lớn hơn 18 ký tự");
            if (dv.ChiPhiTienDuong != null && dv.ChiPhiTienDuong.ToString().Length > 18)
                throw new ValidateException("Chi phí tiền đường không thể lớn hơn 18 ký tự");
            if (dv.ChiPhiKhac != null && dv.ChiPhiKhac.ToString().Length > 18)
                throw new ValidateException("Chi phí khác không thể lớn hơn 18 ký tự");
            if (dv.TongChiPhi != null && dv.TongChiPhi.ToString().Length > 18)
                throw new ValidateException("Tổng chi phí không thể lớn hơn 18 ký tự");
            if (dv.GhiChu != null && dv.GhiChu.ToString().Length > 500)
                throw new ValidateException("Ghi chú không thể lớn hơn 500 ký tự");
        }

        public ResultModelList<VanTai_GetAllChuyenDieuVanTheoChiNhanh_Result> GetAllChuyenDieuVanTheoChiNhanh(int cnid)
        {
            try
            {
                return new ResultModelList<VanTai_GetAllChuyenDieuVanTheoChiNhanh_Result>(true, "", _context.VanTai_GetAllChuyenDieuVanTheoChiNhanh(cnid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<VanTai_GetAllChuyenDieuVanTheoChiNhanh_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<VanTai_ChuyenDieuVan>> Add(VanTai_ChuyenDieuVan dv)
        {
            try
            {
                validateDoiTuong(dv,validateMethod.Add);
                return await base.Add(dv);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<VanTai_ChuyenDieuVan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<VanTai_ChuyenDieuVan>(false, "Có lỗi thêm chuyến điều vận!", null);
            }
        }

        public override async Task<ResultModel<VanTai_ChuyenDieuVan>> Update(VanTai_ChuyenDieuVan kh)
        {
            try
            {
                validateDoiTuong(kh, validateMethod.Update);
                return await base.Update(kh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<VanTai_ChuyenDieuVan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<VanTai_ChuyenDieuVan>(false, "Có lỗi cập nhật chuyến điều vận!", null);
            }
        }

        public async Task UpdateChuyenXe(int LenhVanChuyenId, int ChuyenDieuVanId)
        {
            VanTai_ChuyenDieuVan res = GetById(ChuyenDieuVanId).ResultObj;
            if (res.LenhVanChuyenId == null) res.LenhVanChuyenId = LenhVanChuyenId;
            else if (res.LenhVanChuyen2Id == null) res.LenhVanChuyen2Id = LenhVanChuyenId;
            await Update(res);
        }
    }
}