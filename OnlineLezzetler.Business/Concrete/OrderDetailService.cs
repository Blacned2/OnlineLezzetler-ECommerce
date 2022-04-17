using AutoMapper;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Concrete
{
    public class OrderDetailService : BaseAppService, IOrderDetailService
    {
        private readonly IMapper _mapper;
        public OrderDetailService(OnlineLezzetlerContext context,IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<OrderDetailDto> GetOrderDetail(int id)
        {
            SearchResult<OrderDetailDto> searchResult = new();

            try
            {
                var result = _context.OrderDetails.Find(id);

                if(result != null)
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<OrderDetailDto>(result);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
                    searchResult.ResultType = ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<OrderDetailDto>> GetOrderDetails(int id)
        {
            SearchResult<List<OrderDetailDto>> searchResult = new();

            try
            {
                var results = (from u in _context.OrderDetails
                               join p in _context.Products on u.ProductID equals p.ProductID
                               join s in _context.Suppliers on p.SupplierID equals s.SupplierID
                               where s.SupplierID == id
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage= string.Empty;
                    searchResult.ResultObject = _mapper.Map<List<OrderDetailDto>>(results);
                    searchResult.ResultType= ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
                    searchResult.ResultType = ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }
    }
}
