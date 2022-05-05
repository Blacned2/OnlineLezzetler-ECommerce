using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IEmployeeService
    {
        SearchResult<List<EmployeeDto>> GetEmployees();
        SearchResult<EmployeeDto> GetEmployee(int id);
        SearchResult<EmployeeDto> EditEmployee(int id, EmployeeDto request);    
        SearchResult<bool> AddEmployee(EmployeeDto request);
        SearchResult<bool> DeleteEmployee(int id);
        SearchResult<List<EmployeeDto>> SearchEmployee(EmployeeSearchRequest request);
    }
}
