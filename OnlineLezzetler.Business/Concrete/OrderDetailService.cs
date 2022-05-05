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
        public OrderDetailService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<OrderDetailDto> GetOrderDetail(int orderDetailID)
        {
            SearchResult<OrderDetailDto> searchResult = new();

            try
            {
                var result = _context.OrderDetails.Find(orderDetailID);

                if (result != null)
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

        public SearchResult<List<OrderDetailDto>> GetSupplierOrderDetails(int supplierID)
        {
            SearchResult<List<OrderDetailDto>> searchResult = new();

            try
            {
                var results = (from od in _context.OrderDetails
                               join p in _context.Products
                               on od.ProductID equals p.ProductID
                               where p.SupplierID == supplierID
                               select od).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<List<OrderDetailDto>>(results);
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

        public SearchResult<List<OrderDetailDto>> GetCustomerOrderDetails(int customerID)
        {
            SearchResult<List<OrderDetailDto>> searchResult = new();

            try
            {
                var results = (from o in _context.Orders
                               join od in _context.OrderDetails
                               on o.DetailID equals od.DetailID
                               where o.CustomerID == customerID
                               select od).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<List<OrderDetailDto>>(results);
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

        public SearchResult<bool> AddOrderDetail(OrderDetailDto orderDetail)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                _context.OrderDetails.Add(_mapper.Map<OrderDetail>(orderDetail));
                _context.SaveChanges();
                searchResult.ResultMessage = string.Empty;
                searchResult.ResultObject = true;
                searchResult.ResultType = ResultType.Success;
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultObject = false;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }
    }
}
