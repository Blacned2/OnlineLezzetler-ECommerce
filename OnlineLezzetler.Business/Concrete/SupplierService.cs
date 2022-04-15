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
            SearchResult<bool> searchResult = new SearchResult<bool>();

            try
            {
                var result = _context.Suppliers.Find(id);

                if (result != null)
                {
                    result.IsActive = false;
                    _context.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = string.Empty;
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
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<SupplierDto> EditSupplier(int id, SupplierDto request)
        {
            SearchResult<SupplierDto> searchResult = new SearchResult<SupplierDto>();

            try
            {
                var result = (from u in _context.Suppliers
                              where u.IsActive == true && u.SupplierID == id
                              select u).FirstOrDefault();

                if (result != null)
                {
                    result.Address = NullValidationHelper.StringNullValidation(request.Address); //Bind if not null or empty
                    result.HomePage = NullValidationHelper.StringNullValidation(request.HomePage);
                    result.ContactName = NullValidationHelper.StringNullValidation(request.ContactName);
                    result.CityID = NullValidationHelper.GreaterThanZero(request.CityID); // Bind if greater than 0
                    result.Fax = NullValidationHelper.StringNullValidation(request.Fax);
                    result.Phone = NullValidationHelper.StringNullValidation(request.Phone);
                    result.CompanyName = NullValidationHelper.StringNullValidation(request.CompanyName);

                    _context.Suppliers.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<SupplierDto>(result);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
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

        public SearchResult<SupplierDto> GetSupplier(int id)
        {
            SearchResult<SupplierDto> searchResult = new SearchResult<SupplierDto>();

            try
            {
                var result = (from u in _context.Suppliers
                              where u.SupplierID == id
                              select u).FirstOrDefault();

                if (result != null)
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<SupplierDto>(result);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
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

        public SearchResult<List<SupplierDto>> GetSuppliers()
        {
            SearchResult<List<SupplierDto>> searchResult = new SearchResult<List<SupplierDto>>();

            try
            {
                var results = (from u in _context.Suppliers
                               where u.IsActive == true
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<SupplierDto>>(results);
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

        public SearchResult<List<SupplierDto>> SearchSupplier(SupplierSearchRequest request)
        {
            SearchResult<List<SupplierDto>> searchResult = new SearchResult<List<SupplierDto>>();

            try
            {
                var results = (from u in _context.Suppliers
                               where u.IsActive == true &&
                               !(string.IsNullOrEmpty(request.CompanyName)) || (u.CompanyName.Contains(request.CompanyName)) &&
                               !(string.IsNullOrEmpty(request.CityName)) || (u.City.CityName.Contains(request.CityName))
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<SupplierDto>>(results);
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
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

