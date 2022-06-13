using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_XeVanTaiRepository : BaseRepository<DanhMuc_XeVanTai>
    {
        public ResultModelList<DanhMuc_GetAllXeVanTai_Result> GetAllXeVanTai()
        {
            try
            {
                return new ResultModelList<DanhMuc_GetAllXeVanTai_Result>(true, "", _context.DanhMuc_GetAllXeVanTai().ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<DanhMuc_GetAllXeVanTai_Result>(false, ex.Message, null);
            }
        }
        public override async Task<ResultModel<DanhMuc_XeVanTai>> Add(DanhMuc_XeVanTai kh)
        {
            try
            {
                kh.TrangThai = (int)trangthaiXeVanTai.ChuaChay;
                validateDoiTuong(kh, validateMethod.Add);
                return await base.Add(kh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_XeVanTai>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_XeVanTai>(false, "Có lỗi thêm xe vận tải!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_XeVanTai>> Update(DanhMuc_XeVanTai xeVanTai)
        {
            try
            {
                validateDoiTuong(xeVanTai, validateMethod.Update);
                return await base.Update(xeVanTai);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_XeVanTai>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_XeVanTai>(false, "Có lỗi cập nhật xe vận tải!", null);
            }
        }

        public void validateDoiTuong(DanhMuc_XeVanTai kh, validateMethod method)
        {
            if (string.IsNullOrEmpty(kh.SoXe))
            {
                throw new ValidateException("Số xe vận tải không thể để trống!");
            }
            if (!string.IsNullOrEmpty(kh.SoXe) && kh.SoXe.Length > 50)
            {
                throw new ValidateException("Số xe vận tải không thể dài hơn 50 ký tự!");
            }
            if (kh.HanDangKiem == null) throw new ValidateException("Hạn đăng kiểm không thể để trống!");
            if (method == validateMethod.Add)
            {
                if (_context.DanhMuc_XeVanTai.Count(c => c.SoXe.ToLower() == kh.SoXe.ToLower()) > 0)
                {
                    throw new ValidateException("xe vận tải đã tồn tại!");
                }
            }
        }
    }
}
