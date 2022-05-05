using Microsoft.AspNetCore.Mvc;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System.Collections.Generic; 

namespace OnlineLezzetler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService )
        {
            this._categoryService = categoryService; 
        }

        [HttpGet]
        public ActionResult<List<CategoryDto>> CategoryList()
        {
            var categories = _categoryService.GetCategories();

            return categories.ResultType switch
            {
                ResultType.Success => Ok(categories.ResultObject),
                ResultType.Warning => NotFound(categories.ResultObject),
                ResultType.Error => BadRequest(categories.ResultObject),
                _ => BadRequest(categories.ResultObject),
            };
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetSingleCategory(int id)
        {
            var result = _categoryService.GetSingleCategory(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryDto category)
        {
            var result = _categoryService.AddCategory(category);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpDelete,Route("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpPut,Route("{id}")]
        public ActionResult EditCategory(int id,CategoryDto category)
        {
            var result = _categoryService.EditCategory(id,category);

            return result.ResultType switch
            {
                ResultType.Success => Ok(result.ResultObject),
                ResultType.Warning => NotFound(result.ResultObject),
                ResultType.Error => BadRequest(result.ResultObject),
                _ => BadRequest(result.ResultObject),
            };
        }

        [HttpPost,Route("Search")]
        public ActionResult SearchCategory(CategorySearchRequest search)
        {
            var results = _categoryService.SearchCategories(search);

            return results.ResultType switch
            {
                ResultType.Success => Ok(results.ResultObject),
                ResultType.Warning => NotFound(results.ResultObject),
                ResultType.Error => BadRequest(results.ResultObject),
                _ => BadRequest(results.ResultObject),
            };
        }
    }
}
