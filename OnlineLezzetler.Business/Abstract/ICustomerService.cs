using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface ICustomerService
    {
        SearchResult<List<CustomerDto>> GetCustomers();
        SearchResult<CustomerDto> GetCustomer(int id);
        SearchResult<bool> AddCustomer(CustomerDto customer); 
        SearchResult<bool> EditCustomer(int id,CustomerDto customer);
        SearchResult<List<CustomerDto>> SearchCustomer(string customerName);
    }
}
