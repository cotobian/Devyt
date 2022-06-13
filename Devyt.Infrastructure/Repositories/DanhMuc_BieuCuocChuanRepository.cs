using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_BieuCuocChuanRepository : BaseRepository<DanhMuc_BieuCuocChuan>
    {
        public ResultModelList<DanhMuc_GetAllBieuCuocChuan_Result> GetAllBieuCuocChuan()
        {
            try
            {
                return new ResultModelList<DanhMuc_GetAllBieuCuocChuan_Result>(true, "", _context.DanhMuc_GetAllBieuCuocChuan().ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<DanhMuc_GetAllBieuCuocChuan_Result>(false, ex.Message, null);
            }
        }

        public override async Task<ResultModel<DanhMuc_BieuCuocChuan>> Add(DanhMuc_BieuCuocChuan bcc)
        {
            try
            {
                validateDoiTuong(bcc, validateMethod.Add);
                return await base.Add(bcc);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_BieuCuocChuan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_BieuCuocChuan>(false, "Có lỗi thêm biểu cước chuẩn!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_BieuCuocChuan>> Update(DanhMuc_BieuCuocChuan bcc)
        {
            try
            {
                validateDoiTuong(bcc, validateMethod.Update);
                return await base.Update(bcc);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_BieuCuocChuan>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_BieuCuocChuan>(false, "Có lỗi cập nhật biểu cước chuẩn!", null);
            }
        }

        public void validateDoiTuong(DanhMuc_BieuCuocChuan bcc, validateMethod method)
        {
            if (string.IsNullOrEmpty(bcc.TenBieuCuoc))
            {
                throw new ValidateException("Tên biểu cước không thể để trống!");
            }
            if (!string.IsNullOrEmpty(bcc.TenBieuCuoc) && bcc.TenBieuCuoc.Length > 200)
            {
                throw new ValidateException("Tên biểu cước không thể dài hơn 200 ký tự!");
            }
            if (!string.IsNullOrEmpty(bcc.MaBieuCuoc) && bcc.MaBieuCuoc.Length > 50)
            {
                throw new ValidateException("Mã biểu cước không thể dài hơn 50 ký tự!");
            }
            if (bcc.DonViTinhId == null) throw new ValidateException("Đơn vị tính không thể để trống!");
            if (bcc.DonGia == null || bcc.DonGia < 0) throw new ValidateException("Đơn giá không thể trống hoặc nhỏ hơn 0!");
            if (method == validateMethod.Add)
            {
                if (_context.DanhMuc_BieuCuocChuan.Count(c => c.TenBieuCuoc.ToLower() == bcc.TenBieuCuoc.ToLower()) > 0)
                {
                    throw new ValidateException("Biểu cước đã tồn tại!");
                }
            }
        }

    }
}
