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
    public class CustomerService : BaseAppService, ICustomerService
    {
        private readonly IMapper _mapper;
        public CustomerService(OnlineLezzetlerContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<bool> AddCustomer(CustomerDto customer)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = (from u in _context.Customers
                              where u.Email == customer.Email
                              select u).First();

                if (result == null)
                {
                    _context.Customers.Add(_mapper.Map<Customer>(customer));
                    _context.SaveChanges();

                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Already exist !";
                    searchResult.ResultType = ResultType.Warning;
                    searchResult.ResultObject = false;
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

        public SearchResult<bool> EditCustomer(int id, CustomerDto customer)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Customers.Find(id);

                if (result != null)
                {
                    result.Address = NullValidationHelper.StringNullValidation(customer.Address, result.Address);
                    result.CustomerName = NullValidationHelper.StringNullValidation(customer.CustomerName, result.CustomerName);
                    result.Fax = NullValidationHelper.StringNullValidation(customer.Fax, result.Fax);
                    result.CityID = NullValidationHelper.BindIfNotZero(customer.CityID, result.CityID);
                    result.CompanyName = NullValidationHelper.StringNullValidation(customer.CompanyName, result.CompanyName);
                    result.Phone = NullValidationHelper.StringNullValidation(customer.Phone, result.Phone);

                    _context.Customers.Update(result);
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

        public SearchResult<CustomerDto> GetCustomer(int id)
        {
            SearchResult<CustomerDto> searchResult = new();

            try
            {
                var result = _context.Customers.Find(id);

                if (result != null)
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<CustomerDto>(result);
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

        public SearchResult<List<CustomerDto>> GetCustomers()
        {
            SearchResult<List<CustomerDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Customers
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = _mapper.Map<List<CustomerDto>>(results);
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

        public SearchResult<List<CustomerDto>> SearchCustomer(string customerName)
        {
            SearchResult<List<CustomerDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Customers
                               where u.CustomerName.Contains(customerName)
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<CustomerDto>>(results);
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
