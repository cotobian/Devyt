using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class VanTai_KeHoachVanTaiRepository : BaseRepository<VanTai_KeHoachVanTai>
    {
        public ResultModelList<VanTai_GetAllKeHoachVanTaiTheoChiNhanh_Result> GetAllKeHoachVanTaiTheoChiNhanh(int cnid)
        {
            try
            {
                return new ResultModelList<VanTai_GetAllKeHoachVanTaiTheoChiNhanh_Result>(true, "", _context.VanTai_GetAllKeHoachVanTaiTheoChiNhanh(cnid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<VanTai_GetAllKeHoachVanTaiTheoChiNhanh_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<VanTai_KeHoachVanTai>> Add(VanTai_KeHoachVanTai kh)
        {
            try
            {
                validateDoiTuong(kh);
                return await base.Add(kh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<VanTai_KeHoachVanTai>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<VanTai_KeHoachVanTai>(false, "Có lỗi thêm kế hoạch vận tải!", null);
            }
        }

        public override async Task<ResultModel<VanTai_KeHoachVanTai>> Update(VanTai_KeHoachVanTai kh)
        {
            try
            {
                validateDoiTuong(kh);
                return await base.Update(kh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<VanTai_KeHoachVanTai>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<VanTai_KeHoachVanTai>(false, "Có lỗi cập nhật kế hoạch vận tải!", null);
            }
        }

        public void validateDoiTuong(VanTai_KeHoachVanTai kh)
        {
            if (kh.KhachHangId == null) throw new ValidateException("Khách hàng không thể để trống!");
            if (kh.BillBook == null) throw new ValidateException("Bill/Booking không thể để trống!");
            if (!string.IsNullOrEmpty(kh.BillBook) && kh.BillBook.Length > 50)
            {
                throw new ValidateException("Bill/Booking không thể dài hơn 50 ký tự!");
            }
            if (kh.DiemDiId == null) throw new ValidateException("Điểm đi không thể để trống!");
            if (kh.DiemDenId == null) throw new ValidateException("Điểm đến không thể để trống!");
            if (kh.LoaiHangId == null) throw new ValidateException("Loại hàng không thể để trống!");
            if (!string.IsNullOrEmpty(kh.MatHang) && kh.MatHang.Length > 100)
            {
                throw new ValidateException("Mặt hàng không thể dài hơn 100 ký tự!");
            }
            if (!string.IsNullOrEmpty(kh.NguoiLienLac) && kh.NguoiLienLac.Length > 100)
            {
                throw new ValidateException("Người liên lạc không thể dài hơn 100 ký tự!");
            }
            if (!string.IsNullOrEmpty(kh.GhiChu) && kh.GhiChu.Length > 500)
            {
                throw new ValidateException("Ghi chú không thể dài hơn 500 ký tự!");
            }
        }
    }
}