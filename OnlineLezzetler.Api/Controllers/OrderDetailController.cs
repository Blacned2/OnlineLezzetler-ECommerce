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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            this._orderDetailService = orderDetailService;
        }

        [HttpGet,Route("CustomerOrderDetails")]
        public ActionResult<List<OrderDto>> GetOrderDetailsByCustomerID(int customerID)
        {
            var results = _orderDetailService.GetCustomerOrderDetails(customerID);

            return results.ResultType switch
            {
                ResultType.Success => Ok(results.ResultObject),
                ResultType.Warning => NotFound(results.ResultObject),
                ResultType.Error => BadRequest(results.ResultObject),
                _ => BadRequest(results.ResultObject)
            };
        }

        [HttpGet,Route("SuppliersOrderDetails")]
        public ActionResult<List<OrderDto>> GetSuppliersOrderDetails(int supplierID)
        {
            var results = _orderDetailService.GetSupplierOrderDetails(supplierID);

            return results.ResultType switch
            {
                ResultType.Success => Ok(results.ResultObject),
                ResultType.Warning => NotFound(results.ResultObject),
                ResultType.Error => BadRequest(results.ResultObject),
                _ => BadRequest(results.ResultObject)
            };
        }

        [HttpGet, Route("CustomersOrderDetails")]
        public ActionResult<List<OrderDto>> GetCustomerOrderDetails(int supplierID)
        {
            var results = _orderDetailService.GetCustomerOrderDetails(supplierID);

            return results.ResultType switch
            {
                ResultType.Success => Ok(results.ResultObject),
                ResultType.Warning => NotFound(results.ResultObject),
                ResultType.Error => BadRequest(results.ResultObject),
                _ => BadRequest(results.ResultObject)
            };
        }

        [HttpGet,Route("{id}")]
        public ActionResult<OrderDto> GetOrderDetail(int detailID)
        {
            var result = _orderDetailService.GetOrderDetail(detailID);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpPost]
        public ActionResult<bool> AddOrderDetail(OrderDetailDto orderDetail)
        {
            var result = _orderDetailService.AddOrderDetail(orderDetail);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }
    }
}
