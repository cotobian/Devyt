using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class Admin_PhanQuyenRepository : BaseRepository<Admin_PhanQuyen>
    {
        public override async Task<ResultModel<Admin_PhanQuyen>> Add(Admin_PhanQuyen phanQuyen)
        {
            try
            {
                validateDoiTuong(phanQuyen);
                return await base.Add(phanQuyen);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_PhanQuyen>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_PhanQuyen>(false, "Có lỗi thêm phân quyền!", null);
            }
        }

        public override async Task<ResultModel<Admin_PhanQuyen>> Update(Admin_PhanQuyen phanQuyen)
        {
            try
            {
                validateDoiTuong(phanQuyen);
                return await base.Update(phanQuyen);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_PhanQuyen>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_PhanQuyen>(false, "Có lỗi cập nhật phân quyền!", null);
            }
        }

        public void validateDoiTuong(Admin_PhanQuyen phanQuyen)
        {
            if (string.IsNullOrEmpty(phanQuyen.TenPhanQuyen))
            {
                throw new ValidateException("Tên phân quyền không thể để trống!");
            }
            if (!string.IsNullOrEmpty(phanQuyen.TenPhanQuyen) && phanQuyen.TenPhanQuyen.Length > 50)
            {
                throw new ValidateException("Tên phân quyền không thể dài hơn 50 ký tự!");
            }
            if (string.IsNullOrEmpty(phanQuyen.TenDayDu))
            {
                throw new ValidateException("Tên đầy đủ không thể để trống!");
            }
            if (!string.IsNullOrEmpty(phanQuyen.TenDayDu) && phanQuyen.TenDayDu.Length > 500)
            {
                throw new ValidateException("Tên đầy đủ không thể dài hơn 500 ký tự!");
            }
            if(GetPredicate(c => c.TenPhanQuyen == phanQuyen.TenPhanQuyen && c.Id != phanQuyen.Id) != null)
            {
                throw new ValidateException("Phân quyền đã tồn tại!");
            }
        }
    }
}
