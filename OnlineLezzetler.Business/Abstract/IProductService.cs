using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IProductService
    {
        SearchResult<List<ProductDto>> GetProducts();
        SearchResult<ProductDto> GetProduct(int id);
        SearchResult<bool> DeleteProduct(int id);
        SearchResult<bool> CreateOrEditProduct(int? id, ProductDto product);
        SearchResult<List<ProductDto>> SearchProduct(ProductSearchRequest request);
    }
}
