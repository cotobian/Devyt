using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class Admin_KhoRepository : BaseRepository<Admin_Kho>
    {
        public ResultModelList<Admin_GetAllKho_Result> GetAllKho()
        {
            try
            {
                return new ResultModelList<Admin_GetAllKho_Result>(true, "", _context.Admin_GetAllKho().ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<Admin_GetAllKho_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<Admin_Kho>> Add(Admin_Kho kho)
        {
            try
            {
                validateDoiTuong(kho);
                return await base.Add(kho);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_Kho>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_Kho>(false, "Có lỗi thêm kho!", null);
            }
        }

        public override async Task<ResultModel<Admin_Kho>> Update(Admin_Kho kho)
        {
            try
            {
                validateDoiTuong(kho);
                return await base.Update(kho);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_Kho>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_Kho>(false, "Có lỗi cập nhật kho!", null);
            }
        }

        public void validateDoiTuong(Admin_Kho kho)
        {
            if(string.IsNullOrEmpty(kho.TenKho))
            {
                throw new ValidateException("Tên kho không thể để trống!");
            }
            if(!string.IsNullOrEmpty(kho.TenKho) && kho.TenKho.Length > 500)
            {
                throw new ValidateException("Tên kho không thể dài hơn 500 ký tự!");
            }
            if(kho.ChiNhanhId == null)
            {
                throw new ValidateException("Chi nhánh không thể để trống!");
            }
        }
    }
}