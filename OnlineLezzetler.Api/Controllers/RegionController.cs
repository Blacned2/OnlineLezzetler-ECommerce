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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            this._regionService = regionService;
        }

        [HttpGet, Route("Regions")]
        public ActionResult<List<RegionDto>> RegionList()
        {
            var Regions = _regionService.GetRegions();
            if (Regions.ResultType == ResultType.Success)
            {
                return Ok(Regions.ResultObject);
            }
            else
            {
                return NotFound(Regions.ResultObject);
            }
        }
        [HttpGet, Route("RegionsWithCountries")]
        public ActionResult<List<RegionDto>> RegionListWithCountries()
        {
            var regions = _regionService.GetRegionsWithCountries();
            if (regions.ResultType == ResultType.Success)
            {
                return Ok(regions.ResultObject);
            }
            else
            {
                return NotFound(regions.ResultObject);
            }
        }

        //[HttpGet, Route("Region/{id}")]
        //public ActionResult GetSingleRegion(int id)
        //{
        //    var result = _regionService.GetRegion(id);

        //    if (result.ResultType == ResultType.Success)
        //    {
        //        return Ok(result.ResultObject);
        //    }
        //    else
        //    {
        //        return NotFound(result.ResultObject);
        //    }
        //}

        [HttpPost, Route("Regions/Add")]
        public ActionResult AddRegion(RegionDto region)
        {
            var result = _regionService.AddRegion(region);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return BadRequest(result.ResultObject);
            }
        }

        //[HttpDelete, Route("Regions/Delete")]
        //public ActionResult DeleteRegion(int id)
        //{
        //    var result = _regionService.DeleteRegion(id);

        //    if (result.ResultType == ResultType.Success)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPut, Route("Regions/Edit/{id}")]
        //public ActionResult EditRegion(int id, RegionDto Region)
        //{
        //    var result = _regionService.EditRegion(id, Region);

        //    if (result.ResultType == ResultType.Success)
        //    {
        //        return Ok(result.ResultObject);
        //    }
        //    else
        //    {
        //        return BadRequest(result.ResultObject);
        //    }
        //}

        //[HttpPost, Route("Regions/Search")]
        //public ActionResult SearchRegion(RegionSearchRequest search)
        //{
        //    var results = _regionService.SearchRegion(search);

        //    if (results.ResultType == ResultType.Success)
        //    {
        //        return Ok(results.ResultObject);
        //    }
        //    else
        //    {
        //        return NotFound(results.ResultObject);
        //    }
        //}
    }
}
