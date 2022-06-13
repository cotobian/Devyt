using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_NhaXuatNhapKhauRepository : BaseRepository<DanhMuc_NhaXuatNhapKhau>
    {
        public void validateDoiTuong(DanhMuc_NhaXuatNhapKhau nxk, validateMethod method)
        {
            if (string.IsNullOrEmpty(nxk.TenNhaXNK))
            {
                throw new ValidateException("Tên nhà XNK không thể để trống!");
            }
            if (!string.IsNullOrEmpty(nxk.TenNhaXNK) && nxk.TenNhaXNK.Length > 500)
            {
                throw new ValidateException("Tên nhà XNK không thể dài hơn 500 ký tự!");
            }
            if (method == validateMethod.Add) 
            {
                if (_context.DanhMuc_NhaXuatNhapKhau.Count(c => c.TenNhaXNK.ToLower() == nxk.TenNhaXNK.ToLower()) > 0)
                {
                    throw new ValidateException("Nhà XNK đã tồn tại!");
                }
            }
        }

        public override async Task<ResultModel<DanhMuc_NhaXuatNhapKhau>> Add(DanhMuc_NhaXuatNhapKhau nxk)
        {
            try
            {
                validateDoiTuong(nxk, validateMethod.Add);
                return await base.Add(nxk);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_NhaXuatNhapKhau>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_NhaXuatNhapKhau>(false, "Có lỗi thêm nhà XNK!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_NhaXuatNhapKhau>> Update(DanhMuc_NhaXuatNhapKhau nxk)
        {
            try
            {
                validateDoiTuong(nxk, validateMethod.Update);
                return await base.Update(nxk);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_NhaXuatNhapKhau>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_NhaXuatNhapKhau>(false, "Có lỗi cập nhật nhà XNK!", null);
            }
        }

    }
}
