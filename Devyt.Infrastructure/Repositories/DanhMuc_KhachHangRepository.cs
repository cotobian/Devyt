using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_KhachHangRepository : BaseRepository<DanhMuc_KhachHang>
    {

        public override async Task<ResultModel<DanhMuc_KhachHang>> Add(DanhMuc_KhachHang kh)
        {
            try
            {
                validateDoiTuong(kh, validateMethod.Add);
                return await base.Add(kh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_KhachHang>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_KhachHang>(false, "Có lỗi thêm khách hàng!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_KhachHang>> Update(DanhMuc_KhachHang kh)
        {
            try
            {
                validateDoiTuong(kh, validateMethod.Update);
                return await base.Update(kh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_KhachHang>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_KhachHang>(false, "Có lỗi cập nhật khách hàng!", null);
            }
        }

        public void validateDoiTuong(DanhMuc_KhachHang kh, validateMethod method)
        {
            if(string.IsNullOrEmpty(kh.TenKhachHang))
            {
                throw new ValidateException("Tên khách hàng không thể để trống!");
            }
            if (!string.IsNullOrEmpty(kh.TenVietTat) && kh.TenVietTat.Length > 200)
            {
                throw new ValidateException("Tên khách hàng không thể dài hơn 200 ký tự!");
            }
            if (!string.IsNullOrEmpty(kh.TenKhachHang) && kh.TenKhachHang.Length > 1000)
            {
                throw new ValidateException("Tên khách hàng không thể dài hơn 100 ký tự!");
            }
            if (!string.IsNullOrEmpty(kh.DiaChi) && kh.DiaChi.Length > 1000)
            {
                throw new ValidateException("Địa chỉ không thể dài hơn 1000 ký tự!");
            }
            if (!string.IsNullOrEmpty(kh.MaSoThue) && kh.MaSoThue.Length > 50)
            {
                throw new ValidateException("Mã số thuế không thể dài hơn 50 ký tự!");
            }
            if (!string.IsNullOrEmpty(kh.NguoiLienLac) && kh.NguoiLienLac.Length > 50)
            {
                throw new ValidateException("Người liên lạc không thể dài hơn 50 ký tự!");
            }
            if(method == validateMethod.Add)
            {
                if (_context.DanhMuc_KhachHang.Count(c => c.TenKhachHang.ToLower() == kh.TenKhachHang.ToLower()) > 0)
                {
                    throw new ValidateException("khách hàng đã tồn tại!");
                }
            }
        }
    }
}
