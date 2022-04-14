using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Concrete;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IRegionService
    {
        SearchResult<List<RegionDto>> GetRegions();
        SearchResult<RegionDto> GetRegion(int id);
        SearchResult<RegionDto> AddRegion(RegionDto region);
        SearchResult<List<Region>> GetRegionsWithCountries();
        SearchResult<bool> DeleteRegion(int id);
        SearchResult<List<RegionDto>> SearchRegion(RegionSearchRequest request);
    }
}
