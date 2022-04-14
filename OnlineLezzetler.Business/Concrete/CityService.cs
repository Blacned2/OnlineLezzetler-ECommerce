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
    public class CityService : BaseAppService, ICityService
    {
        private readonly IMapper _mapper;
        public CityService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<CityDto> AddCity(CityDto city)
        {
            SearchResult<CityDto> searchResult = new SearchResult<CityDto>();

            try
            {
                var result = (from u in _context.Cities
                              where u.CityName.ToLower() == city.CityName.ToLower()
                              select u).FirstOrDefault();

                if (result != null && result.IsActive == false)
                {
                    result.IsActive = true;
                    _context.Cities.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = city;
                    searchResult.ResultType = ResultType.Success;
                }
                else if (result != null && result.IsActive == true)
                {
                    searchResult.ResultMessage = "Already exist !";
                    searchResult.ResultType = ResultType.Warning;
                    searchResult.ResultObject = _mapper.Map<CityDto>(result);
                }
                else
                {
                    _context.Cities.Add(_mapper.Map<City>(city));
                    _context.SaveChanges();
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = city;
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

        public SearchResult<bool> DeleteCity(int id)
        {
            SearchResult<bool> searchResult = new SearchResult<bool>();

            try
            {
                var result = _context.Cities.Find(id);

                if (result != null)
                {
                    result.IsActive = false;
                    _context.Cities.Update(result);
                    _context.SaveChanges();
                    searchResult.ResultObject = true;
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultObject = false;
                    searchResult.ResultType = ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultObject = false;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<CityDto> EditCity(int id, CityDto city)
        {
            SearchResult<CityDto> searchResult = new SearchResult<CityDto>();

            try
            {
                var result = _context.Cities.Find(id);

                if (result != null)
                {
                    if (city.CityName != null)
                    {
                        result.CityName = city.CityName;
                    }
                    if (city.PostalCode != null)
                    {
                        result.PostalCode = city.PostalCode;
                    }
                    _context.Cities.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultObject = _mapper.Map<CityDto>(result);
                    searchResult.ResultMessage = string.Empty;
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

        public SearchResult<List<CityDto>> GetCities()
        {
            SearchResult<List<CityDto>> searchResult = new SearchResult<List<CityDto>>();

            try
            {
                var results = (from u in _context.Cities
                               where u.IsActive == true
                               select u).ToList();

                if (results.Count > 0)
                {
                    searchResult.ResultObject = _mapper.Map<List<CityDto>>(results);
                    searchResult.ResultMessage = string.Empty;
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

        public SearchResult<List<City>> GetCitiesWithRelations()
        {
            SearchResult<List<City>> searchResult = new SearchResult<List<City>>();

            try
            {
                var results = (from u in _context.Cities
                               where u.IsActive == true
                               select u).ToList();

                if(results.Count > 0)
                {
                    searchResult.ResultObject = _mapper.Map<List<City>>(results);
                    searchResult.ResultMessage= string.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
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

        public SearchResult<CityDto> GetCity(int id)
        {
            SearchResult<CityDto> searchResult = new SearchResult<CityDto>();

            try
            {
                var result = (from u in _context.Cities
                              where u.IsActive == true
                              select u).FirstOrDefault();

                if(result != null)
                {
                    searchResult.ResultObject = _mapper.Map<CityDto>(result);
                    searchResult.ResultType = ResultType.Success;
                    searchResult.ResultMessage= string.Empty;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
                    searchResult.ResultType= ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<CityDto>> SearchCity(CitySearchRequest city)
        {
            SearchResult<List<CityDto>> searchResult = new SearchResult<List<CityDto>>();

            try
            {
                var results = (from u in _context.Cities
                               where u.IsActive == true &&
                               (string.IsNullOrEmpty(city.CityName) || (u.CityName.Contains(city.CityName)) &&
                               (string.IsNullOrEmpty(city.PostalCode) || (u.PostalCode == city.PostalCode)) &&
                               (string.IsNullOrEmpty(city.RegionDescription) || (u.Region.RegionDescription == city.RegionDescription)))
                               select u).ToList();

                if (results.Count > 0)
                {
                    searchResult.ResultObject = _mapper.Map<List<CityDto>>(results);
                    searchResult.ResultMessage = string.Empty;
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
    }
}
