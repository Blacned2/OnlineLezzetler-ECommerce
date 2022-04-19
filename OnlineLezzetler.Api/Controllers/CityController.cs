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
            return cities.ResultType switch
            {
                ResultType.Success => Ok(cities.ResultObject),
                ResultType.Warning => NotFound(cities.ResultObject),
                ResultType.Error => BadRequest(cities.ResultObject),
                _ => BadRequest(cities.ResultObject)
            };
        }

        [HttpGet, Route("CityListsWithRelations")]
        public ActionResult<List<City>> GetCityListWithRelations()
        {
            var cities = _cityService.GetCitiesWithRelations();
            return cities.ResultType switch
            {
                ResultType.Success => Ok(cities.ResultObject),
                ResultType.Warning => NotFound(cities.ResultObject),
                ResultType.Error => BadRequest(cities.ResultObject),
                _ => BadRequest(cities.ResultObject)
            };
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetCity(int id)
        {
            var result = _cityService.GetCity(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpPost]
        public ActionResult AddCity(CityDto city)
        {
            var result = _cityService.AddCity(city);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpDelete, Route("{id}")]
        public ActionResult DeleteCity(int id)
        {
            var result = _cityService.DeleteCity(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpPut,Route("{id}")]
        public ActionResult EditCity(int id, CityDto city)
        {
            var result = _cityService.EditCity(id, city);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject)
            };
        }

        [HttpPost, Route("Search")]
        public ActionResult SearchCity(CitySearchRequest search)
        {
            var results = _cityService.SearchCity(search);

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
