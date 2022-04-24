using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System.Collections.Generic;

namespace OnlineLezzetler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet, Route("CustomerOrders")]
        public ActionResult<HashSet<OrderDto>> GetCustomerOrders(int id) //Customer gets order...
        {
            var results = _orderService.GetCustomerOrders(id);

            return results.ResultType switch
            {
                ResultType.Success => Ok(results.ResultObject),
                ResultType.Warning => NotFound(results.ResultObject),
                ResultType.Error => BadRequest(results.ResultObject),
                _ => BadRequest(results.ResultObject)
            };
        }

        [HttpGet, Route("CustomerOrder")]
        public ActionResult<OrderDto> GetCustomerOrder(int customerID, int orderID) //Supplier Orders
        {
            var result = _orderService.GetCustomerOrder(customerID, orderID);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpGet, Route("SupplierOrder")]
        public ActionResult<OrderDto> GetSupplierOrder(int supplierID, int orderID) //Supplier Orders
        {
            var result = _orderService.GetSupplierOrder(supplierID, orderID);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpGet, Route("SupplierOrders")]
        public ActionResult<OrderDto> GetSupplierOrders(int supplierID) //Supplier Orders
        {
            var result = _orderService.GetSupplierOrders(supplierID);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        //[HttpPost]
        //public ActionResult<OrderDto> NewOrder(OrderDto order)
        //{
        //    var result = _orderService.NewOrder(order);

        //}
    }
}
