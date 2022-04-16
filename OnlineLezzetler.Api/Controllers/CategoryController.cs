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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<CategoryDto>> CategoryList()
        {
            var categories = _categoryService.GetCategories();
            if(categories.ResultType == ResultType.Success)
            {
                return Ok(categories.ResultObject);
            }
            else
            {
                return NotFound(categories.ResultObject);
            }
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetSingleCategory(int id)
        {
            var result = _categoryService.GetSingleCategory(id);

            if (result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return NotFound(result.ResultObject);
            }
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryDto category)
        {
            var result = _categoryService.AddCategory(category);

            if(result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return BadRequest(result.ResultObject);
            }
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);

            if(result.ResultType == ResultType.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult EditCategory(int id,CategoryDto category)
        {
            var result = _categoryService.EditCategory(id,category);

            if(result.ResultType == ResultType.Success)
            {
                return Ok(result.ResultObject);
            }
            else
            {
                return BadRequest(result.ResultObject);
            }
        }

        [HttpPost,Route("Search")]
        public ActionResult SearchCategory(CategorySearchRequest search)
        {
            var results = _categoryService.SearchCategories(search);

            if(results.ResultType == ResultType.Success)
            {
                return Ok(results.ResultObject);
            }
            else
            {
                return NotFound(results.ResultObject);
            }
        }
    }
}
