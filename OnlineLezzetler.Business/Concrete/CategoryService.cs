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
    public class CategoryService : BaseAppService, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<CategoryDto> AddCategory(CategoryDto category)
        {
            SearchResult<CategoryDto> searchResult = new SearchResult<CategoryDto>();

            try
            {
                var result = (from u in _context.Categories
                              where u.CategoryName == category.CategoryName
                              select u).FirstOrDefault();

                if (result != null && result.IsDeleted == true)
                {
                    result.IsDeleted = false;
                    result.Description = category.Description;
                    _context.Categories.Update(result);
                    _context.SaveChanges();
                    searchResult.ResultObject = _mapper.Map<CategoryDto>(result);
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;

                }
                else if (result != null && result.IsDeleted == false)
                {
                    searchResult.ResultMessage = "Ayni kategori mevcut!";
                    searchResult.ResultObject = null;
                    searchResult.ResultType = ResultType.Error;
                }
                else
                {
                    _context.Categories.Add(_mapper.Map<Category>(category));
                    _context.SaveChanges();
                    searchResult.ResultObject = category;
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<bool> DeleteCategory(int id)
        {
            SearchResult<bool> searchResult = new SearchResult<bool>();

            try
            {
                var result = _context.Categories.Find(id);
                if (result != null)
                {
                    result.IsDeleted = true;
                    _context.Categories.Update(result);
                    _context.SaveChangesAsync();
                    searchResult.ResultObject = true;
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Bulunamadi !";
                    searchResult.ResultObject = false;
                    searchResult.ResultType = ResultType.Error;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<CategoryDto> EditCategory(int id, CategoryDto category)
        {
            SearchResult<CategoryDto> searchResult = new SearchResult<CategoryDto>();

            try
            {
                var result = _context.Categories.Find(id);

                if (result != null)
                {
                    if(category.CategoryName != null)
                    {
                        result.CategoryName = category.CategoryName;
                    }
                    if(category.Description != null)
                    {
                        result.Description = category.Description;
                    }
                    _context.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<CategoryDto>(result);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Bulunamadi !";
                    searchResult.ResultType = ResultType.Error;
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

        public SearchResult<List<CategoryDto>> GetCategories()
        {
            SearchResult<List<CategoryDto>> searchResult = new SearchResult<List<CategoryDto>>();

            try
            {
                var results = (from u in _context.Categories
                               where u.IsDeleted == false
                               select u).ToList();

                if (results != null)
                {
                    searchResult.ResultObject = _mapper.Map<List<CategoryDto>>(results);
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Bulunamadi";
                    searchResult.ResultObject = null;
                    searchResult.ResultType = ResultType.Error;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<CategoryDto> GetSingleCategory(int id)
        {
            SearchResult<CategoryDto> searchResult = new SearchResult<CategoryDto>();

            try
            {
                var result = (from u in _context.Categories
                              where u.CategoryID == id && u.IsDeleted == false
                              select u).FirstOrDefault();

                if(result != null)
                {
                    searchResult.ResultObject= _mapper.Map<CategoryDto>(result);
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Bulunamadi";
                    searchResult.ResultObject = null;
                    searchResult.ResultType = ResultType.Error;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<CategoryDto>> SearchCategories(CategorySearchRequest request)
        {
            SearchResult<List<CategoryDto>> searchResult = new SearchResult<List<CategoryDto>>();

            try
            {
                var results = (from u in _context.Categories
                               where u.IsDeleted == false &&
                               (request.Description == null || u.Description.Contains(request.Description) &&
                               request.CategoryName == null || u.CategoryName.Contains(request.CategoryName))
                               select u).ToList();
                if(results.Count > 0)
                {
                    searchResult.ResultObject = _mapper.Map<List<CategoryDto>>(results);
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Arattiginiz sonuc bulunamadi";
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
