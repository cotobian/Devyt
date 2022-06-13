using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public class Report_BaoCaoKhoRepository:BaseRepository<NhapXuat_HangNhap>
    {
        public ResultModelList<Report_BaoCaoTonKho_Result> GetBaoCaoTonKho(int cnid)
        {
            try
            {
                return new ResultModelList<Report_BaoCaoTonKho_Result>(true, "", _context.Report_BaoCaoTonKho(cnid).ToList());
            }
            catch (Exception ex)
            {
                return new ResultModelList<Report_BaoCaoTonKho_Result>(false, ex.Message, null);
            }
        }
    }
}
