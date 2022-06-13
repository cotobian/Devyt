using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System.Linq;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_LoaiHangRepository : BaseRepository<DanhMuc_LoaiHang>
    {
        public void ValidateDoiTuong(DanhMuc_LoaiHang lh, validateMethod method)
        {
            if (string.IsNullOrEmpty(lh.TenLoaiHang))
            {
                throw new ValidateException("Tên loại hàng không thể để trống!");
            }
            if (!string.IsNullOrEmpty(lh.TenLoaiHang) && lh.TenLoaiHang.Length > 50)
            {
                throw new ValidateException("Tên loại hàng không thể dài hơn 50 ký tự!");
            }
            if (method == validateMethod.Add)
            {
                if (_context.DanhMuc_LoaiHang.Count(c => c.TenLoaiHang.ToLower() == lh.TenLoaiHang.ToLower()) > 0)
                {
                    throw new ValidateException("Tên loại hàng đã tồn tại!");
                }
            }
            if (method == validateMethod.Update)
            {
                if (_context.DanhMuc_LoaiHang.Count(c => c.Id != lh.Id && c.TenLoaiHang.ToLower() == lh.TenLoaiHang.ToLower()) > 0)
                {
                    throw new ValidateException("Tên loại hàng đã tồn tại!");
                }
            }
        }
    }
}