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
    public class SupplierService : BaseAppService, ISupplierService
    {
        private readonly IMapper _mapper;
        public SupplierService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<bool> AddSupplier(SupplierDto request)
        {
            SearchResult<bool> searchResult = new SearchResult<bool>();

            try
            {
                var result = (from u in _context.Suppliers
                              where u.CompanyName == request.CompanyName
                              select u).FirstOrDefault();

                if (result == null)
                {
                    _context.Suppliers.Add(_mapper.Map<Supplier>(request));
                    _context.SaveChanges();
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else if (result != null && result.IsActive == false)
                {
                    result.IsActive = true;
                    result.Address = NullValidationHelper.StringNullValidation(request.Address); //Bind if not null or empty
                    result.HomePage = NullValidationHelper.StringNullValidation(request.HomePage);
                    result.ContactName = NullValidationHelper.StringNullValidation(request.ContactName);
                    result.CityID = NullValidationHelper.GreaterThanZero(request.CityID); // Bind if greater than 0
                    result.Fax = NullValidationHelper.StringNullValidation(request.Fax);
                    result.Phone = NullValidationHelper.StringNullValidation(request.Phone);

                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Already exist !";
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

        public SearchResult<bool> DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public SearchResult<SupplierDto> EditSupplier(int id, SupplierDto request)
        {
            throw new NotImplementedException();
        }

        public SearchResult<SupplierDto> GetSupplier()
        {
            throw new NotImplementedException();
        }

        public SearchResult<List<SupplierDto>> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public SearchResult<List<SupplierDto>> SearchSupplier(SupplierSearchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
