using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_DiaDiemRepository : BaseRepository<DanhMuc_DiaDiem>
    {
        public override async Task<ResultModel<DanhMuc_DiaDiem>> Add(DanhMuc_DiaDiem PhongBan)
        {
            try
            {
                validateDoiTuong(PhongBan);
                return await base.Add(PhongBan);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_DiaDiem>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_DiaDiem>(false, "Có lỗi thêm địa điểm!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_DiaDiem>> Update(DanhMuc_DiaDiem PhongBan)
        {
            try
            {
                validateDoiTuong(PhongBan);
                return await base.Update(PhongBan);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_DiaDiem>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_DiaDiem>(false, "Có lỗi cập nhật địa điểm!", null);
            }
        }

        public void validateDoiTuong(DanhMuc_DiaDiem diaDiem)
        {
            if (string.IsNullOrEmpty(diaDiem.TenDiaDiem))
            {
                throw new ValidateException("Tên địa điểm không thể để trống!");
            }
            if (!string.IsNullOrEmpty(diaDiem.TenDiaDiem) && diaDiem.TenDiaDiem.Length > 50)
            {
                throw new ValidateException("Tên địa điểm không thể dài hơn 50 ký tự!");
            }
        }
    }
}