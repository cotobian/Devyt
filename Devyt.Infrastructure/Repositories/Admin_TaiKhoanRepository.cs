using Devyt.Infrastructure.Common;
using Devyt.Models;
using Devyt.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class Admin_TaiKhoanRepository : BaseRepository<Admin_TaiKhoan>
    {
        private HashString _hash = new HashString();

        public async Task<ResultModel<Admin_TaiKhoan>> GetByAccount(LoginViewModel model)
        {
            try
            {
                string hashPass = _hash.GetHashString(model.Password);
                Admin_TaiKhoan result = await _context.Admin_TaiKhoan.Where(c => c.MatKhau == hashPass && c.TaiKhoan == model.UserName).FirstOrDefaultAsync();
                return new ResultModel<Admin_TaiKhoan>(true, "", result);
            }
            catch (Exception ex)
            {
                return new ResultModel<Admin_TaiKhoan>(false, ex.Message, null);
            }
        }

        public ResultModelList<Admin_GetAllTaiKhoan_Result> GetAllTaiKhoan()
        {
            try
            {
                return new ResultModelList<Admin_GetAllTaiKhoan_Result>(true, "", _context.Admin_GetAllTaiKhoan().ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<Admin_GetAllTaiKhoan_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<Admin_TaiKhoan>> Add(Admin_TaiKhoan kho)
        {
            try
            {
                validateDoiTuong(kho);
                return await base.Add(kho);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_TaiKhoan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_TaiKhoan>(false, "Có lỗi thêm tài khoản!", null);
            }
        }

        public override async Task<ResultModel<Admin_TaiKhoan>> Update(Admin_TaiKhoan kho)
        {
            try
            {
                validateDoiTuong(kho);
                return await base.Update(kho);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_TaiKhoan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_TaiKhoan>(false, "Có lỗi cập nhật tài khoản!", null);
            }
        }

        public async Task<int> GetChiNhanhId(int pbid)
        {
            try
            {
                int res = (int)await _context.Admin_PhongBan.Where(c => c.Id == pbid).Select(c => c.ChiNhanhId).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void validateDoiTuong(Admin_TaiKhoan taiKhoan)
        {

        }
    }
}