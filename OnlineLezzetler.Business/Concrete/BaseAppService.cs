using OnlineLezzetler.Data; 

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
