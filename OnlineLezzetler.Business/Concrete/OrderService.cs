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
                    if (result.OrderDate <= result.OrderDate.AddMinutes(2)) // We cancel the order in 2 min ,then we can't
                    {
                        result.IsCancelled = true;
                    }
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
                searchResult.ResultObject = false;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<OrderDto> GetCustomerOrder(int customerID, int orderID)
        {
            SearchResult<OrderDto> searchResult = new();

            try
            {
                var result = (from u in _context.Orders
                              where u.CustomerID == customerID
                              && u.OrderID == orderID
                              select u).FirstOrDefault();

                if (result != null)
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

        public SearchResult<HashSet<OrderDto>> GetCustomerOrders(int id)
        {
            SearchResult<HashSet<OrderDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Orders
                               where u.IsCancelled == false && u.CustomerID == id
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

        public SearchResult<OrderDto> GetSupplierOrder(int supplierID, int orderID)
        {
            SearchResult<OrderDto> searchResult = new();

            try
            {
                var result = (from order in _context.Orders
                              join detail in _context.OrderDetails
                              on
                              order.DetailID equals detail.DetailID
                              join
                              product in _context.Products
                              on
                              detail.ProductID equals product.ProductID
                              join
                              supplier in _context.Suppliers
                              on
                              product.SupplierID equals supplier.SupplierID
                              where supplier.SupplierID == supplierID && order.OrderID == orderID
                              select order).FirstOrDefault();

                if (result != null)
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

        public SearchResult<HashSet<OrderDto>> GetSupplierOrders(int supplierID)
        {
            SearchResult<HashSet<OrderDto>> searchResult = new();

            try
            {
                var results = (from order in _context.Orders
                               join detail in _context.OrderDetails
                               on order.DetailID equals detail.DetailID
                               join product in _context.Products
                               on detail.ProductID equals product.ProductID
                               join supplier in _context.Suppliers
                               on product.SupplierID equals supplier.SupplierID
                               where supplier.SupplierID == supplierID
                               select order).ToHashSet();

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

        public SearchResult<bool> NewOrder(OrderDto order)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                if(order.ShipperID == 4)
                {
                    //TODO
                    //order.ShipperID = (from o in _context.Orders
                    //                   join od in _context.OrderDetails
                    //                   on o.DetailID equals od.DetailID
                    //                   join p in _context.Products
                    //                   on od.ProductID equals p.ProductID
                    //                   join s in _context.Suppliers
                    //                   on p.SupplierID equals s.SupplierID
                    //                   select s.Phone).First();
                }
                order.ShippedCityID = (from u in _context.Orders
                                       select u.Customer.CityID).FirstOrDefault();

                _context.Orders.Add(_mapper.Map<Order>(order));
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

        public SearchResult<bool> OrderDelivered(int id)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = (from u in _context.Orders
                              where u.OrderID == id && u.IsCancelled == false
                              && u.IsDelivered == false
                              select u).FirstOrDefault();

                if (result != null)
                {
                    result.IsDelivered = true;
                    _context.Orders.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found!";
                    searchResult.ResultObject = false;
                    searchResult.ResultType = ResultType.Warning;
                }
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
