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
    public class EmployeeService : BaseAppService, IEmployeeService
    {
        private readonly IMapper _mapper;
        public EmployeeService(OnlineLezzetlerContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public SearchResult<bool> AddEmployee(EmployeeDto request)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = (from u in _context.Employees
                              where (u.FirstName.ToLower()
                              + " " +
                              u.LastName.ToLower()) == (request.FirstName.ToLower()
                              + " " + 
                              request.LastName.ToLower())
                              select u).FirstOrDefault();

                if(result == null)
                {
                    _context.Employees.Add(_mapper.Map<Employee>(request));
                    _context.SaveChanges();
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else if(result != null && result.IsFired == true) //ReHired to the job
                {
                    result.IsFired = false;
                    result.Title = NullValidationHelper.StringNullValidation(request.Title, result.Title); 
                    result.Phone = NullValidationHelper.StringNullValidation(request.Phone, result.Phone);
                    result.EmployeeCityID = NullValidationHelper.BindIfNotZero(request.EmployeeCityID, result.City.CityID);
                    result.Address = NullValidationHelper.StringNullValidation(request.Address, result.Address);
                    result.Salary = NullValidationHelper.BindIfNotZero(request.Salary, result.Salary);
                    result.HiredDate = NullValidationHelper.BindDateTimeIfNotNull(request.HiredDate, result.HiredDate);
                    result.Notes = NullValidationHelper.StringNullValidation(request.Notes, result.Notes);
                    result.PhotoPath = NullValidationHelper.StringNullValidation(request.PhotoPath, result.PhotoPath);

                    _context.Employees.Update(result);
                    _context.SaveChanges();

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

        public SearchResult<bool> DeleteEmployee(int id)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Employees.Find(id);

                if(result != null)
                {
                    result.IsFired = true;
                    _context.Employees.Update(result);
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
                searchResult.ResultObject= false;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<EmployeeDto> EditEmployee(int id, EmployeeDto request)
        {
            SearchResult<EmployeeDto> searchResult = new();

            try
            {
                var result = (from u in _context.Employees
                              where u.IsFired == false && u.EmployeeID == id
                              select u).FirstOrDefault();

                if(result != null)
                {
                    result.Title = NullValidationHelper.StringNullValidation(request.Title, result.Title);
                    result.FirstName = NullValidationHelper.StringNullValidation(request.FirstName, result.FirstName);
                    result.LastName = NullValidationHelper.StringNullValidation(request.LastName, result.LastName);
                    result.Phone = NullValidationHelper.StringNullValidation(request.Phone, result.Phone);
                    result.EmployeeCityID = NullValidationHelper.BindIfNotZero(request.EmployeeCityID, result.EmployeeCityID);
                    result.Address = NullValidationHelper.StringNullValidation(request.Address, result.Address);
                    result.Salary = NullValidationHelper.BindIfNotZero(request.Salary, result.Salary);
                    result.Notes = NullValidationHelper.StringNullValidation(request.Notes, result.Notes);
                    result.PhotoPath = NullValidationHelper.StringNullValidation(request.PhotoPath, result.PhotoPath);

                    _context.Employees.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<EmployeeDto>(result);
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

        public SearchResult<EmployeeDto> GetEmployee(int id)
        {
            SearchResult<EmployeeDto> searchResult = new();

            try
            {
                var result = (from u in _context.Employees
                              where u.IsFired == false
                              select u).FirstOrDefault();

                if(result != null)
                {
                    searchResult.ResultObject = _mapper.Map<EmployeeDto>(result);
                    searchResult.ResultMessage = string.Empty;
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

        public SearchResult<List<EmployeeDto>> GetEmployees()
        {
            SearchResult<List<EmployeeDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Employees
                               where u.IsFired == false
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultObject = _mapper.Map<List<EmployeeDto>>(results);
                    searchResult.ResultMessage= string.Empty;
                    searchResult.ResultType= ResultType.Success;
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

        public SearchResult<List<EmployeeDto>> SearchEmployee(EmployeeSearchRequest request)
        {
            SearchResult<List<EmployeeDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Employees
                               where u.IsFired == false &&
                               (string.IsNullOrEmpty(request.EmployeeName) ||
                               u.FirstName.Contains(request.EmployeeName) || u.LastName.Contains(request.EmployeeName) &&
                               (string.IsNullOrEmpty(request.EmployeeCityName) || u.City.CityName.Contains(request.EmployeeCityName)))
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultObject = _mapper.Map<List<EmployeeDto>>(results);
                    searchResult.ResultType = ResultType.Success;
                    searchResult.ResultMessage = String.Empty;
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
