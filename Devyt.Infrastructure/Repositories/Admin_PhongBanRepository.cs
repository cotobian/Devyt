using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class Admin_PhongBanRepository : BaseRepository<Admin_PhongBan>
    {
        public ResultModelList<Admin_GetAllPhongBan_Result> GetAllPhongBan()
        {
            try
            {
                return new ResultModelList<Admin_GetAllPhongBan_Result>(true, "", _context.Admin_GetAllPhongBan().ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<Admin_GetAllPhongBan_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<Admin_PhongBan>> Add(Admin_PhongBan PhongBan)
        {
            try
            {
                validateDoiTuong(PhongBan);
                return await base.Add(PhongBan);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_PhongBan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_PhongBan>(false, "Có lỗi thêm phòng ban!", null);
            }
        }

        public override async Task<ResultModel<Admin_PhongBan>> Update(Admin_PhongBan PhongBan)
        {
            try
            {
                validateDoiTuong(PhongBan);
                return await base.Update(PhongBan);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_PhongBan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_PhongBan>(false, "Có lỗi cập nhật phòng ban!", null);
            }
        }

        public void validateDoiTuong(Admin_PhongBan PhongBan)
        {
            if (string.IsNullOrEmpty(PhongBan.TenPhongBan))
            {
                throw new ValidateException("Tên phòng ban không thể để trống!");
            }
            if (!string.IsNullOrEmpty(PhongBan.TenPhongBan) && PhongBan.TenPhongBan.Length > 50)
            {
                throw new ValidateException("Tên phòng ban không thể dài hơn 50 ký tự!");
            }
            if (PhongBan.ChiNhanhId == null)
            {
                throw new ValidateException("Chi nhánh không thể để trống!");
            }
        }
    }
}
