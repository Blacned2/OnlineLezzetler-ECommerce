using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface ICountryService
    {
        SearchResult<List<CountryDto>> GetCountries();
        SearchResult<CountryDto> GetCountry(int id);
        SearchResult<CountryDto> EditCountry(int id, CountryDto country);
        SearchResult<bool> DeleteCountry(int id);
        SearchResult<List<CountryDto>> SearchCountry(CountrySearchRequest country);
        SearchResult<CountryDto> AddCountry(CountryDto country);
    }
}
