using AutoMapper;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Helper;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace OnlineLezzetler.Business.Concrete
{
    public class CountryService : BaseAppService, ICountryService
    {
        private readonly IMapper _mapper;
        public CountryService(OnlineLezzetlerContext context,IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<CountryDto> AddCountry(CountryDto country)
        {
            SearchResult<CountryDto> searchResult = new();

            try
            {
                var result = (from u in _context.Countries
                              where u.CountryName == country.CountryName ||
                              u.CountryShortName == country.CountryShortName
                              select u).FirstOrDefault();

                if(result == null)
                {
                    country.CountryShortName = country.CountryName.ToUpper();
                    result = _mapper.Map<Country>(country);
                    _context.Countries.Add(result);
                    _context.SaveChanges();
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = country;
                    searchResult.ResultType = ResultType.Success;
                }
                else if(result != null && result.IsActive == false)
                {
                    result.IsActive = true;
                    _context.Update(result);
                    _context.SaveChanges();
                    searchResult.ResultObject = country;
                    searchResult.ResultMessage= String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "It is already exist !";
                    searchResult.ResultObject = country;
                    searchResult.ResultType = ResultType.Warning;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType= ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<bool> DeleteCountry(int id)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Countries.Find(id);

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
                    searchResult.ResultMessage = "Not found !";
                    searchResult.ResultObject = false;
                    searchResult.ResultType = ResultType.Error;
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

        public SearchResult<CountryDto> EditCountry(int id, CountryDto country)
        {
            SearchResult<CountryDto> searchResult = new();

            try
            {
                var result = _context.Countries.Find(id);

                if(result != null)
                {
                    result.CountryName = NullValidationHelper.StringNullValidation(country.CountryName, result.CountryName);
                    result.CountryShortName = NullValidationHelper.StringNullValidation(country.CountryShortName,result.CountryShortName);
                    _context.Update(result);
                    _context.SaveChanges();
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<CountryDto>(result);
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
                searchResult.ResultObject = null;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<CountryDto>> GetCountries()
        {
            SearchResult<List<CountryDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Countries
                               where u.IsActive == true
                               select u).ToList();

                if(results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<CountryDto>>(results);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
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

        public SearchResult<CountryDto> GetCountry(int id)
        {
            SearchResult<CountryDto> searchResult = new();

            try
            {
                var result = _context.Countries.Find(id);

                if(result != null)
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<CountryDto>(result);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
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

        public SearchResult<List<CountryDto>> SearchCountry(CountrySearchRequest country)
        {
            SearchResult<List<CountryDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Countries
                               where u.IsActive == true &&
                               (country.CountryName == null || u.CountryName.Contains(country.CountryName) &&
                               country.CountryShortName == null || u.CountryShortName == country.CountryShortName)
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultObject = _mapper.Map<List<CountryDto>>(results);
                    searchResult.ResultMessage = string.Empty;
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
    }
}
