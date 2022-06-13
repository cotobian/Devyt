using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_TaiXeRepository : BaseRepository<DanhMuc_TaiXe>
    {
        public void validateDoiTuong(DanhMuc_TaiXe tx, validateMethod method)
        {
            if (string.IsNullOrEmpty(tx.TenLaiXe))
            {
                throw new ValidateException("Tên tài xế không thể để trống!");
            }
            if (!string.IsNullOrEmpty(tx.TenLaiXe) && tx.TenLaiXe.Length > 100)
            {
                throw new ValidateException("Tên tài xế không thể dài hơn 100 ký tự!");
            }
            if (string.IsNullOrEmpty(tx.SoDienThoai))
            {
                throw new ValidateException("Số điện thoại không thể để trống!");
            }
            if (!string.IsNullOrEmpty(tx.SoDienThoai) && tx.SoDienThoai.Length > 50)
            {
                throw new ValidateException("Số điện thoại không thể dài hơn 50 ký tự!");
            }
            if (!string.IsNullOrEmpty(tx.GPLX) && tx.GPLX.Length > 50)
            {
                throw new ValidateException("Số giấy phép lái xe không thể dài hơn 50 ký tự!");
            }
            if (!string.IsNullOrEmpty(tx.CMND) && tx.CMND.Length > 50)
            {
                throw new ValidateException("Số CMND không thể dài hơn 50 ký tự!");
            }
        }
        public ResultModelList<DanhMuc_GetAllTaiXeByChiNhanh_Result> GetAllTaiXe(int cnid)
        {
            try
            {
                return new ResultModelList<DanhMuc_GetAllTaiXeByChiNhanh_Result>(true, "", _context.DanhMuc_GetAllTaiXeByChiNhanh(cnid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<DanhMuc_GetAllTaiXeByChiNhanh_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<DanhMuc_TaiXe>> Add(DanhMuc_TaiXe kh)
        {
            try
            {
                validateDoiTuong(kh, validateMethod.Add);
                return await base.Add(kh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_TaiXe>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_TaiXe>(false, "Có lỗi thêm tài xế!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_TaiXe>> Update(DanhMuc_TaiXe TaiXe)
        {
            try
            {
                validateDoiTuong(TaiXe, validateMethod.Update);
                return await base.Update(TaiXe);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_TaiXe>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_TaiXe>(false, "Có lỗi cập nhật tài xế!", null);
            }
        }
    }
}
