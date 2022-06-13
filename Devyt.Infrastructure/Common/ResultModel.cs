using System.Collections.Generic;

namespace Devyt.Infrastructure.Common
{
    public class ResultModel<T> where T : class
    {
        public ResultModel(bool resSuccess, string resMessage, T resList)
        {
            isSuccessed = resSuccess;
            Message = resMessage;
            ResultObj = resList;
        }
        public bool isSuccessed { get; set; }
        public string Message { get; set; }
        public T ResultObj { get; set; }
    }
}