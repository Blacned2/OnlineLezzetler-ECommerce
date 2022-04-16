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
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Concrete
{
    public class ProductService : BaseAppService, IProductService
    {
        private readonly IMapper _mapper;
        public ProductService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<bool> CreateOrEditProduct(int? id, ProductDto product)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Products.Find(id);

                if (result == null)
                {
                    _context.Products.Add(_mapper.Map<Product>(product));
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    NullValidationHelper.StringNullValidation(product.ProductName, result.ProductName);
                    NullValidationHelper.BindIfNotZero(product.CategoryID, result.CategoryID);
                    NullValidationHelper.BindIfNotZero(product.SupplierID, result.SupplierID);
                    NullValidationHelper.BindIfNotZero(product.UnitPrice, result.UnitPrice);
                    NullValidationHelper.BindIfNotZero(product.UnitInStock, result.UnitInStock);
                    NullValidationHelper.BindIfNotZero(product.UnitOnOrder, result.UnitOnOrder);
                    result.DisContinued = product.DisContinued;

                    _context.Products.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultMessage = ex.Message;
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultObject = false;
            }
            return searchResult;
        }

        public SearchResult<bool> DeleteProduct(int id)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Products.Find(id);

                if (result != null)
                {
                    result.DisContinued = true;
                    _context.Products.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
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

        public SearchResult<ProductDto> GetProduct(int id)
        {
            SearchResult<ProductDto> searchResult = new();

            try
            {
                var result = (from u in _context.Products
                              where u.DisContinued == false && u.ProductID == id
                              select u).FirstOrDefault();

                if (result != null)
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<ProductDto>(result);
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

        public SearchResult<List<ProductDto>> GetProducts()
        {
            SearchResult<List<ProductDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Products
                               where u.DisContinued == false
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<ProductDto>>(results);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
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

        public SearchResult<List<ProductDto>> SearchProduct(ProductSearchRequest request)
        {
            SearchResult<List<ProductDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Products
                               where u.DisContinued == false &&
                               (string.IsNullOrEmpty(request.ProductName) || u.ProductName.Contains(request.ProductName)) &&
                               (string.IsNullOrEmpty(request.CategoryName) || u.Category.CategoryName.Contains(request.CategoryName))
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<ProductDto>>(results);
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
