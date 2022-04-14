using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data.Models;
using System.Collections.Generic;

namespace OnlineLezzetler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            this._cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<CityDto>> GetCityList()
        {
            var cities = _cityService.GetCities();
            if (cities.ResultType == ResultType.Success)
            {
                return Ok(cities.ResultObject);
            }
            else
            {
                return NotFound(cities.ResultObject);
            }
        }

        [HttpGet,Route("GetCityListsWithRelations")]
        public ActionResult<List<City>> GetCityListWithRelations()
        {
            var cities = _cityService.GetCitiesWithRelations();
            if (cities.ResultType == ResultType.Success)
            {
                return Ok(cities.ResultObject);
            }
            else
            {
                return NotFound(cities.ResultObject);
            }
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetCity(int id)
        {
            var result = _cityService.GetCity(id);

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
        public ActionResult AddCity(CityDto city)
        {
            var result = _cityService.AddCity(city);

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
        public ActionResult DeleteCity(int id)
        {
            var result = _cityService.DeleteCity(id);

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
        public ActionResult EditCity(int id, CityDto city)
        {
            var result = _cityService.EditCity(id, city);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return BadRequest(result.ResultObject);
            }
        }

        [HttpPost, Route("Search")]
        public ActionResult SearchCity(CitySearchRequest search)
        {
            var results = _cityService.SearchCity(search);

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
