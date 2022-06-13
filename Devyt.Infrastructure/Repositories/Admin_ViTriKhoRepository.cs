using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class Admin_ViTriKhoRepository : BaseRepository<Admin_ViTriKho>
    {
        public ResultModelList<Admin_GetAllViTriKho_Result> GetAllViTriKho()
        {
            try
            {
                return new ResultModelList<Admin_GetAllViTriKho_Result>(true, "", _context.Admin_GetAllViTriKho().ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<Admin_GetAllViTriKho_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<Admin_ViTriKho>> Add(Admin_ViTriKho kho)
        {
            try
            {
                validateDoiTuong(kho);
                return await base.Add(kho);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_ViTriKho>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_ViTriKho>(false, "Có lỗi thêm vị trí kho!", null);
            }
        }

        public override async Task<ResultModel<Admin_ViTriKho>> Update(Admin_ViTriKho kho)
        {
            try
            {
                validateDoiTuong(kho);
                return await base.Update(kho);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<Admin_ViTriKho>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<Admin_ViTriKho>(false, "Có lỗi cập nhật vị trí kho!", null);
            }
        }

        public void validateDoiTuong(Admin_ViTriKho kho)
        {
            if (string.IsNullOrEmpty(kho.ViTri))
            {
                throw new ValidateException("Vị trí kho không thể để trống!");
            }
            if (!string.IsNullOrEmpty(kho.ViTri) && kho.ViTri.Length > 50)
            {
                throw new ValidateException("Vị trí kho không thể dài hơn 500 ký tự!");
            }
            if (kho.KhoId == null)
            {
                throw new ValidateException("Kho chọn không thể để trống!");
            }
            if(_context.Admin_ViTriKho.Count(c => c.ViTri.ToLower() == kho.ViTri.ToLower() && c.KhoId == kho.KhoId) > 0)
            {
                throw new ValidateException("Vị trí kho đã tồn tại!");
            }
        }
    }
}
