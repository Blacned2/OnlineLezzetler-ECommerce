using AutoMapper;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Helper;
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
    public class OrderService : BaseAppService, IOrderService
    {
        private readonly IMapper _mapper;
        public OrderService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<bool> CancelOrder(int id)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Orders.Find(id);

                if (result != null)
                {
                    result.IsCancelled = true;
                    _context.Orders.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
                    searchResult.ResultObject = false;
                    searchResult.ResultType = ResultType.Warning;
                }

            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultObject= false;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<bool> EditOrder(int id, OrderDto order,OrderDetailDto details)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Orders.Find(id);

                if(result != null && result.ShippedDate > DateTime.Now)
                {
                    result.OrderDate = DateTime.Now;
                    result.OrderDetail.Quantity = NullValidationHelper.BindIfNotZero(details.Quantity, result.OrderDetail.Quantity);
                    result.RequiredDate = DateTime.Now.AddMinutes(30);
                    result.ShippedCityID = NullValidationHelper.BindIfNotZero(order.ShippedCityID, (int)result.ShippedCityID);

                    result.OrderDetail.OrderPrice = details.Products.UnitPrice;
                    _context.Orders.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage =ex.Message;
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = false;
            }
            return searchResult;
        }
         
        public SearchResult<OrderDto> GetOrder(int id)
        {
            SearchResult<OrderDto> searchResult = new();

            try
            {
                var result = _context.Orders.Find(id);

                if(result != null)
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<OrderDto>(result);
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

        public SearchResult<HashSet<OrderDto>> GetOrders()
        {
            SearchResult<HashSet<OrderDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Orders
                               where u.IsCancelled == false
                               select u).ToHashSet();

                if (results.Any())
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<HashSet<OrderDto>>(results);
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

        public SearchResult<bool> NewOrder(Order order)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                order.OrderDetail.OrderPrice = order.OrderDetail.Product.UnitPrice;
                _context.Orders.Add(order);
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
