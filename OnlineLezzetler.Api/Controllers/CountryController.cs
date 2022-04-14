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

        [HttpGet, Route("Countries")]
        public ActionResult<List<CountryDto>> CountryList()
        {
            var countries = _countryService.GetCountries();
            if (countries.ResultType == ResultType.Success)
            {
                return Ok(countries.ResultObject);
            }
            else
            {
                return NotFound(countries.ResultObject);
            }
        }

        [HttpGet, Route("Country/{id}")]
        public ActionResult GetSingleCountry(int id)
        {
            var result = _countryService.GetCountry(id);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return NotFound(result.ResultObject);
            }
        }

        [HttpPost, Route("Countries/Add")]
        public ActionResult AddCountry(CountryDto Country)
        {
            var result = _countryService.AddCountry(Country);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return BadRequest(result.ResultObject);
            }
        }

        [HttpDelete, Route("Countries/Delete")]
        public ActionResult DeleteCountry(int id)
        {
            var result = _countryService.DeleteCountry(id);

            if (result.ResultType == ResultType.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut, Route("Countries/Edit/{id}")]
        public ActionResult EditCountry(int id, CountryDto country)
        {
            var result = _countryService.EditCountry(id, country);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return BadRequest(result.ResultObject);
            }
        }

        [HttpPost, Route("Countries/Search")]
        public ActionResult SearchCountry(CountrySearchRequest search)
        {
            var results = _countryService.SearchCountry(search);

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
