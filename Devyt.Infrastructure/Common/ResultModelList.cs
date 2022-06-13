using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Common
{
    public class ResultModelList<T> where T : class
    {
        public ResultModelList(bool resSuccess, string resMessage, List<T> resList)
        {
            isSuccessed = resSuccess;
            Message = resMessage;
            ResultObj = resList;
        }
        public bool isSuccessed { get; set; }
        public string Message { get; set; }
        public List<T> ResultObj { get; set; }
    }
}
