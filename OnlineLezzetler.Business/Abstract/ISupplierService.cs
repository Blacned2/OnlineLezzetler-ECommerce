using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface ISupplierService
    {
        SearchResult<List<SupplierDto>> GetSuppliers();
        SearchResult<SupplierDto> GetSupplier();
        SearchResult<SupplierDto> EditSupplier(int id,SupplierDto request);
        SearchResult<bool> AddSupplier(SupplierDto request);
        SearchResult<bool> DeleteSupplier(int id);
        SearchResult<List<SupplierDto>> SearchSupplier(SupplierSearchRequest request);

    }
}
