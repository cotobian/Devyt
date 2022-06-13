using Devyt.Infrastructure.Common;
using Devyt.Infrastructure.Enums;
using Devyt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class NhapXuat_LoHangRepository : BaseRepository<NhapXuat_LoHang>
    {
        public ResultModelList<NhapXuat_GetAllLoHangByChiNhanh_Result> GetAllLoHangByChiNhanh(int chinhanhid)
        {
            List<NhapXuat_GetAllLoHangByChiNhanh_Result> val = _context.NhapXuat_GetAllLoHangByChiNhanh(chinhanhid).ToList();
            return new ResultModelList<NhapXuat_GetAllLoHangByChiNhanh_Result>(true, null, val);
        }

        public override async Task<ResultModel<NhapXuat_LoHang>> Add(NhapXuat_LoHang lh)
        {
            try
            {
                lh.TrangThai = (int)trangthaiLoHang.KhoiTao;
                validateDoiTuong(lh, validateMethod.Add);
                return await base.Add(lh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<NhapXuat_LoHang>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<NhapXuat_LoHang>(false, "Có lỗi thêm lô hàng!", null);
            }
        }

        public override async Task<ResultModel<NhapXuat_LoHang>> Update(NhapXuat_LoHang lh)
        {
            try
            {
                validateDoiTuong(lh, validateMethod.Update);
                return await base.Update(lh);
            }
            catch (ValidateException ex)
            {
                return new ResultModel<NhapXuat_LoHang>(false, ex.Message, null);
            }
            catch (Exception)
            {
                return new ResultModel<NhapXuat_LoHang>(false, "Có lỗi cập nhật lô hàng!", null);
            }
        }


        public void validateDoiTuong(NhapXuat_LoHang lh, validateMethod method)
        {
            if (string.IsNullOrEmpty(lh.SoToKhai))
            {
                throw new ValidateException("Số tờ khai không thể để trống!");
            }
            if (!string.IsNullOrEmpty(lh.SoToKhai) && lh.SoToKhai.Length > 50)
            {
                throw new ValidateException("Số tờ khai không thể dài hơn 50 ký tự!");
            }
            if (lh.NgayToKhai == null) throw new ValidateException("Ngày tờ khai không thể để trống!");
            if (string.IsNullOrEmpty(lh.SoHopDong))
            {
                throw new ValidateException("Số hợp đồng không thể để trống!");
            }
            if (!string.IsNullOrEmpty(lh.SoHopDong) && lh.SoHopDong.Length > 50)
            {
                throw new ValidateException("Số hợp đồng không thể dài hơn 50 ký tự!");
            }
            if (lh.NgayHopDong == null) throw new ValidateException("Ngày hợp đồng không thể để trống!");
            if (lh.KhoId == null) throw new ValidateException("Kho nhập không thể để trống!");
        }
    }
}
