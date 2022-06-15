using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class VanTai_LenhVanChuyenRepository : BaseRepository<VanTai_LenhVanChuyen>
    {
        public ResultModelList<VanTai_GetAllLenhVanChuyenTheoChiNhanh_Result> GetAllLenhVanChuyenTheoChiNhanh(int cnid)
        {
            try
            {
                return new ResultModelList<VanTai_GetAllLenhVanChuyenTheoChiNhanh_Result>(true, "", _context.VanTai_GetAllLenhVanChuyenTheoChiNhanh(cnid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<VanTai_GetAllLenhVanChuyenTheoChiNhanh_Result>(false, ex.Message, null);
            }
        }

        public ResultModelList<VanTai_GetLenhVanChuyenTheoKeHoach_Result> GetLenhVanChuyenTheoKeHoach(int kehoachid)
        {
            try
            {
                return new ResultModelList<VanTai_GetLenhVanChuyenTheoKeHoach_Result>(true, "", _context.VanTai_GetLenhVanChuyenTheoKeHoach(kehoachid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<VanTai_GetLenhVanChuyenTheoKeHoach_Result>(false, ex.Message, null);
            }
        }

        public async Task<ResultModel<string>> AddBatch(VanTai_LenhVanChuyen con, int soluong)
        {
            try
            {
                for(int i=0;i<soluong;i++)
                {
                    VanTai_LenhVanChuyen val = new VanTai_LenhVanChuyen();
                    val.ChiNhanhId = con.ChiNhanhId;
                    val.DonViTinhId = con.DonViTinhId;
                    val.KeHoachVanTaiId = con.KeHoachVanTaiId;
                    val.TrangThai = 0;
                    _context.VanTai_LenhVanChuyen.Add(val);
                }
                await _context.SaveChangesAsync();
                return new ResultModel<string>(true, null, null);
            }
            catch (Exception ex)
            {
                return new ResultModel<string>(false, ex.Message, null);
            }
        }
    }
}