using AutoMapper;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Concrete
{
    public class RegionService : BaseAppService, IRegionService
    {
        private readonly IMapper _mapper;
        public RegionService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<RegionDto> AddRegion(RegionDto region)
        {
            SearchResult<RegionDto> searchResult = new();

            try
            {
                var result = (from u in _context.Regions
                              where u.RegionDescription.ToLower() == region.RegionDescription.ToLower()
                              select u).FirstOrDefault();

                if (result != null && result.IsActive == false)
                {
                    searchResult.ResultMessage = String.Empty;
                    result.IsActive = true;
                    result.CountryID = region.CountryID;
                    _context.Regions.Update(result);
                    _context.SaveChanges();
                    searchResult.ResultObject = region;
                    searchResult.ResultType = ResultType.Success;
                }
                else if (result != null && result.IsActive == true)
                {
                    searchResult.ResultMessage = "Already exist !";
                    searchResult.ResultType = ResultType.Warning;
                    searchResult.ResultObject = _mapper.Map<RegionDto>(result);
                }
                else
                {
                    _context.Regions.Add(_mapper.Map<Region>(region));
                    _context.SaveChanges();
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = region;
                    searchResult.ResultType = ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultObject = null;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<bool> DeleteRegion(int id)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = (from u in _context.Regions
                              where u.RegionID == id
                              select u).FirstOrDefault();

                if(result != null)
                {
                    result.IsActive = false;
                    _context.Update(result);
                    _context.SaveChanges();
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultType = ResultType.Warning;
                    searchResult.ResultObject = false;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<RegionDto> GetRegion(int id)
        {
            SearchResult<RegionDto> searchResult = new();

            try
            {
                var result = (from u in _context.Regions
                              where u.IsActive == true && u.RegionID == id
                              select u).FirstOrDefault();

                if (result != null)
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<RegionDto>(result);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultType = ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<RegionDto>> GetRegions()
        {
            SearchResult<List<RegionDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Regions
                               where u.IsActive == true
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<List<RegionDto>>(results);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultType = ResultType.Warning;
                    searchResult.ResultObject = null;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<RegionDto>> GetRegionsByCountryID(int id)
        {
            SearchResult<List<RegionDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Regions
                               where u.CountryID == id && u.IsActive == true
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<RegionDto>>(results);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultType = ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<Region>> GetRegionsWithCountries()
        {
            SearchResult<List<Region>> searchResult = new();

            try
            {
                var results = (from u in _context.Regions
                               where u.IsActive == true
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = results;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultType = ResultType.Warning;
                    searchResult.ResultObject = null;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<RegionDto>> SearchRegion(RegionSearchRequest request)
        {
            SearchResult<List<RegionDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Regions
                               where u.IsActive == true && (request.CountryID == null || u.CountryID == request.CountryID)
                               && (string.IsNullOrEmpty(request.CountryName) || u.Country.CountryName.Contains(request.CountryName))
                               && (string.IsNullOrEmpty(request.RegionName) || u.RegionDescription.Contains(request.RegionName))
                               select u).ToList(); 
                               
                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<RegionDto>>(results);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultObject = null;
                    searchResult.ResultType = ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }
    }
}
