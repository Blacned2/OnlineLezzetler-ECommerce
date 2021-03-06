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
        SearchResult<HashSet<SupplierDto>> GetSuppliers();
        SearchResult<HashSet<SupplierDto>> GetSuppliersByCityID(int id);
        SearchResult<SupplierDto> GetSupplier(int id);
        SearchResult<SupplierDto> EditSupplier(int id,SupplierDto request);
        SearchResult<bool> AddSupplier(SupplierDto request);
        SearchResult<bool> DeleteSupplier(int id);
        SearchResult<List<SupplierDto>> SearchSupplier(SupplierSearchRequest request);

    }
}
