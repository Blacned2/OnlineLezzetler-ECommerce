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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        [HttpGet]
        public ActionResult<List<CountryDto>> CountryList()
        {
            var countries = _countryService.GetCountries();

            return countries.ResultType switch
            {
                ResultType.Success => Ok(countries.ResultObject),
                ResultType.Warning => NotFound(countries.ResultObject),
                ResultType.Error => BadRequest(countries.ResultObject),
                _ => BadRequest(countries.ResultObject),
            };
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetSingleCountry(int id)
        {
            var result = _countryService.GetCountry(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpPost]
        public ActionResult AddCountry(CountryDto Country)
        {
            var result = _countryService.AddCountry(Country);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpDelete, Route("{id}")]
        public ActionResult DeleteCountry(int id)
        {
            var result = _countryService.DeleteCountry(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpPut,Route("{id}")]
        public ActionResult EditCountry(int id, CountryDto country)
        {
            var result = _countryService.EditCountry(id, country);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpPost, Route("Search")]
        public ActionResult SearchCountry(CountrySearchRequest search)
        {
            var results = _countryService.SearchCountry(search);

            return results.ResultType switch
            {
                ResultType.Success => Ok(results.ResultObject),
                ResultType.Warning => NotFound(results.ResultObject),
                ResultType.Error => BadRequest(results.ResultObject),
                _ => BadRequest(results.ResultObject),
            };
        }
    }
}
