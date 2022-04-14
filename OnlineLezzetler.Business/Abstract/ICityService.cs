using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface ICityService
    {
        SearchResult<List<CityDto>> GetCities();
        SearchResult<CityDto> GetCity(int id);
        SearchResult<CityDto> EditCity(int id, CityDto city);
        SearchResult<bool> DeleteCity(int id);
        SearchResult<List<CityDto>> SearchCity(CitySearchRequest city);
        SearchResult<CityDto> AddCity(CityDto city);
        SearchResult<List<City>> GetCitiesWithRelations();
    }
}
