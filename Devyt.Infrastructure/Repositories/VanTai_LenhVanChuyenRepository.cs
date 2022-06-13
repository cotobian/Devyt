using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;

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
    }
}