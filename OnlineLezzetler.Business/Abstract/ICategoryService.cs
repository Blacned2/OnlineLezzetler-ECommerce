using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface ICategoryService
    {
        SearchResult<List<CategoryDto>> GetCategories();
        SearchResult<CategoryDto> GetSingleCategory(int id);
        SearchResult<CategoryDto> AddCategory(CategoryDto category);
        SearchResult<bool> DeleteCategory(int id);
        SearchResult<List<CategoryDto>> SearchCategories(CategorySearchRequest request);
        SearchResult<CategoryDto> EditCategory(int id, CategoryDto category);

    }
}
