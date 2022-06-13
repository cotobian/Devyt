using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class NhapXuat_HangXuatRepository : BaseRepository<NhapXuat_HangXuat>
    {
        public void validateDoiTuong(NhapXuat_HangXuat dvt)
        {
            if (string.IsNullOrEmpty(dvt.SoToKhai))
            {
                throw new ValidateException("Số tờ khai không thể để trống!");
            }
            if (!string.IsNullOrEmpty(dvt.SoToKhai) && dvt.SoToKhai.Length > 50)
            {
                throw new ValidateException("Số tờ khai không thể dài hơn 50 ký tự!");
            }
            if (dvt.SoKien == null) throw new ValidateException("Số kiện không thể để trống!");
            if (!string.IsNullOrEmpty(dvt.SoContXuat) && dvt.SoContXuat.Length > 50)
            {
                throw new ValidateException("Số container xuất không thể dài hơn 50 ký tự!");
            }
            if (dvt.HangNhapId == null) throw new ValidateException("Lô hàng nhập không thể để trống!");
        }

        public override async Task<ResultModel<NhapXuat_HangXuat>> Add(NhapXuat_HangXuat dvt)
        {
            try
            {
                validateDoiTuong(dvt);
                return await base.Add(dvt);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<NhapXuat_HangXuat>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<NhapXuat_HangXuat>(false, "Có lỗi thêm hàng xuất!", null);
            }
        }

        public ResultModelList<NhapXuat_GetAllHangXuatByChiNhanh_Result> GetAllHangXuatByChiNhanh(int cnid)
        {
            try
            {
                return new ResultModelList<NhapXuat_GetAllHangXuatByChiNhanh_Result>(true, "", _context.NhapXuat_GetAllHangXuatByChiNhanh(cnid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<NhapXuat_GetAllHangXuatByChiNhanh_Result>(false, ex.Message, null);
            }
        }
    }
}