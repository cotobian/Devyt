using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_DonViTinhRepository : BaseRepository<DanhMuc_DonViTinh>
    {
        public override async Task<ResultModel<DanhMuc_DonViTinh>> Add(DanhMuc_DonViTinh dvt)
        {
            try
            {
                validateDoiTuong(dvt,validateMethod.Add);
                return await base.Add(dvt);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_DonViTinh>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_DonViTinh>(false, "Có lỗi thêm đơn vị tính!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_DonViTinh>> Update(DanhMuc_DonViTinh dvt)
        {
            try
            {
                validateDoiTuong(dvt,validateMethod.Update);
                return await base.Update(dvt);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_DonViTinh>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_DonViTinh>(false, "Có lỗi cập nhật đơn vị tính!", null);
            }
        }

        public void validateDoiTuong(DanhMuc_DonViTinh dvt, validateMethod method)
        {
            if (string.IsNullOrEmpty(dvt.TenDonViTinh))
            {
                throw new ValidateException("Tên đơn vị tính không thể để trống!");
            }
            if (!string.IsNullOrEmpty(dvt.TenDonViTinh) && dvt.TenDonViTinh.Length > 50)
            {
                throw new ValidateException("Tên đơn vị tính không thể dài hơn 50 ký tự!");
            }
            if (!string.IsNullOrEmpty(dvt.GhiChu) && dvt.GhiChu.Length > 200)
            {
                throw new ValidateException("Ghi chú không thể dài hơn 200 ký tự!");
            }
            if(method == validateMethod.Add)
            {
                if (_context.DanhMuc_DonViTinh.Count(c => c.TenDonViTinh.ToLower() == dvt.TenDonViTinh.ToLower()) > 0)
                {
                    throw new ValidateException("Đơn vị tính đã tồn tại!");
                }
            }
        }
    }
}
