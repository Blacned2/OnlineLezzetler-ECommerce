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
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        public ShipperController(IShipperService shipperService)
        {
            this._shipperService = shipperService;
        }

        [HttpGet]
        public ActionResult<List<ShipperDto>> ShipperList()
        {
            var result = _shipperService.GetShippers();
            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetSingleShipper(int id)
        {
            var result = _shipperService.GetShipper(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpPost]
        public ActionResult AddShipper(ShipperDto supplier)
        {

            var result = _shipperService.AddShipper(supplier);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpDelete, Route("{id}")]
        public ActionResult DeleteShipper(int id)
        {
            var result = _shipperService.DeleteShipper(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpPut, Route("{id}")]
        public ActionResult EditShipper(int id, ShipperDto supplier)
        {
            var result = _shipperService.EditShipper(id, supplier);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpPost, Route("Search")]
        public ActionResult SearchShipper(ShipperSearchRequest search)
        {
            var results = _shipperService.SearchShipper(search);

            return results.ResultType switch
            {
                ResultType.Success => Ok(results.ResultObject),
                ResultType.Warning => NotFound(results.ResultObject),
                ResultType.Error => BadRequest(results.ResultObject),
                _ => BadRequest(results.ResultObject)
            };
        }
    }
}
