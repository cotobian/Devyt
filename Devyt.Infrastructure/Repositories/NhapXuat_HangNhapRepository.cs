using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class NhapXuat_HangNhapRepository : BaseRepository<NhapXuat_HangNhap>
    {
        public void validateDoiTuong(NhapXuat_HangNhap dvt)
        {
            if (string.IsNullOrEmpty(dvt.TenHang))
            {
                throw new ValidateException("Tên hàng không thể để trống!");
            }
            if (!string.IsNullOrEmpty(dvt.TenHang) && dvt.TenHang.Length > 250)
            {
                throw new ValidateException("Tên hàng không thể dài hơn 250 ký tự!");
            }
            if (dvt.SoKien == null) throw new ValidateException("Số kiện không thể để trống!");
            if (!string.IsNullOrEmpty(dvt.SoContNhap) && dvt.SoContNhap.Length > 50)
            {
                throw new ValidateException("Số container nhập không thể dài hơn 50 ký tự!");
            }
            if (!string.IsNullOrEmpty(dvt.XuatXu) && dvt.XuatXu.Length > 250)
            {
                throw new ValidateException("Xuất xứ không thể dài hơn 250 ký tự!");
            }
        }

        public override async Task<ResultModel<NhapXuat_HangNhap>> Add(NhapXuat_HangNhap dvt)
        {
            try
            {
                validateDoiTuong(dvt);
                dvt.TrangThai = (int)trangthaiHangNhap.KhoiTao;
                return await base.Add(dvt);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<NhapXuat_HangNhap>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<NhapXuat_HangNhap>(false, "Có lỗi thêm hàng nhập!", null);
            }
        }

        public ResultModelList<NhapXuat_GetAllHangNhapByChiNhanh_Result> GetAllHangNhapByChiNhanh(int cnid)
        {
            try
            {
                return new ResultModelList<NhapXuat_GetAllHangNhapByChiNhanh_Result>(true, "", _context.NhapXuat_GetAllHangNhapByChiNhanh(cnid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<NhapXuat_GetAllHangNhapByChiNhanh_Result>(false, ex.Message, null);
            }
        }
    }
}
