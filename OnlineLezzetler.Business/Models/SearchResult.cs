using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Models
{
    public class SearchResult<T>
    {
        public T ResultObject { get; set; }
        public ResultType ResultType { get; set; }
        public string ResultMessage { get; set; }
    }
    public enum ResultType : byte
    {
        Success = 0,
        Error = 1,
        Warning = 2
    }
}
