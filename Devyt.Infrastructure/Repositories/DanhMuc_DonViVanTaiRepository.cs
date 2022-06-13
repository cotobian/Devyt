using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class DanhMuc_DonViVanTaiRepository : BaseRepository<DanhMuc_DonViVanTai>
    {
        public void ValidateDoiTuong(DanhMuc_DonViVanTai dvt, validateMethod method)
        {
            if(string.IsNullOrEmpty(dvt.TenDonViVanTai))
            {
                throw new ValidateException("Tên đơn vị vận tải không thể để trống!");
            }
            if (!string.IsNullOrEmpty(dvt.TenDonViVanTai) && dvt.TenDonViVanTai.Length > 500)
            {
                throw new ValidateException("Tên đơn vị vận tải không thể dài hơn 500 ký tự!");
            }
            if (string.IsNullOrEmpty(dvt.TenVietTat))
            {
                throw new ValidateException("Tên viết tắt không thể để trống!");
            }
            if (!string.IsNullOrEmpty(dvt.TenVietTat) && dvt.TenVietTat.Length > 50)
            {
                throw new ValidateException("Tên viết tắt không thể dài hơn 50 ký tự!");
            }
            if (method == validateMethod.Add)
            {
                if (_context.DanhMuc_DonViVanTai.Count(c => c.TenDonViVanTai.ToLower() == dvt.TenDonViVanTai.ToLower() || c.TenVietTat.ToLower() == dvt.TenVietTat.ToLower()) > 0)
                {
                    throw new ValidateException("Tên đơn vị vận tải hoặc Tên viết tắt đã tồn tại!");
                }
            }
            if(method == validateMethod.Update)
            {
                if (_context.DanhMuc_DonViVanTai.Count(c => c.Id != dvt.Id && c.TenDonViVanTai.ToLower() == dvt.TenDonViVanTai.ToLower() || c.TenVietTat.ToLower() == dvt.TenVietTat.ToLower()) > 0)
                {
                    throw new ValidateException("Tên đơn vị vận tải hoặc Tên viết tắt đã tồn tại!");
                }
            }
        }

        public override async Task<ResultModel<DanhMuc_DonViVanTai>> Add(DanhMuc_DonViVanTai dvt)
        {
            try
            {
                ValidateDoiTuong(dvt, validateMethod.Add);
                return await base.Add(dvt);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_DonViVanTai>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_DonViVanTai>(false, "Có lỗi thêm đơn vị vận tải!", null);
            }
        }

        public override async Task<ResultModel<DanhMuc_DonViVanTai>> Update(DanhMuc_DonViVanTai dvt)
        {
            try
            {
                ValidateDoiTuong(dvt, validateMethod.Update);
                return await base.Update(dvt);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_DonViVanTai>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_DonViVanTai>(false, "Có lỗi cập nhật đơn vị vận tải!", null);
            }
        }

        public async Task<ResultModel<DanhMuc_DonViVanTai>> Delete(DanhMuc_DonViVanTai dvt)
        {
            try
            {
                dvt.TrangThai = false;
                return await base.Update(dvt);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<DanhMuc_DonViVanTai>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<DanhMuc_DonViVanTai>(false, "Có lỗi xóa đơn vị vận tải!", null);
            }
        }
    }
}