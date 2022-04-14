using OnlineLezzetler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Concrete
{
    public class BaseAppService
    {
        public readonly OnlineLezzetlerContext _context;
        public BaseAppService(OnlineLezzetlerContext context)
        {
            this._context = context;
        }
    }
}
