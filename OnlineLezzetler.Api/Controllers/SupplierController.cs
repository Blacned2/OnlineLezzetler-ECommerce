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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<List<SupplierDto>> SupplierList()
        {
            var Suppliers = _supplierService.GetSuppliers();
            if (Suppliers.ResultType == ResultType.Success)
            {
                return Ok(Suppliers.ResultObject);
            }
            else
            {
                return NotFound(Suppliers.ResultObject);
            }
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetSingleSupplier(int id)
        {
            var result = _supplierService.GetSupplier(id);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return NotFound(result.ResultObject);
            }
        }

        [HttpPost]
        public ActionResult AddSupplier(SupplierDto supplier)
        {
            var result = _supplierService.AddSupplier(supplier);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return BadRequest(result.ResultObject);
            }
        }

        [HttpDelete]
        public ActionResult DeleteSupplier(int id)
        {
            var result = _supplierService.DeleteSupplier(id);

            if (result.ResultType == ResultType.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut, Route("{id}")]
        public ActionResult EditSupplier(int id, SupplierDto supplier)
        {
            var result = _supplierService.EditSupplier(id, supplier);

            switch (result.ResultType)
            {
                case ResultType.Success:
                    return Ok(result.ResultObject);
                case ResultType.Warning:
                    return NotFound(result.ResultObject);
                case ResultType.Error:
                    return BadRequest(result.ResultObject);
                default: return BadRequest(result.ResultObject);
            }
        }

        [HttpPost, Route("Search")]
        public ActionResult SearchSupplier(SupplierSearchRequest search)
        {
            var results = _supplierService.SearchSupplier(search);

            if (results.ResultType == ResultType.Success)
            {
                return Ok(results.ResultObject);
            }
            else
            {
                return NotFound(results.ResultObject);
            }
        }
    }
}
