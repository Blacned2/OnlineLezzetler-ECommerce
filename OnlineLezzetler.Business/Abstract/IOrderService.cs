using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IOrderService
    {
        SearchResult<HashSet<OrderDto>> GetOrders();
        SearchResult<OrderDto> GetOrder(int id);
        SearchResult<bool> NewOrder(Order order);
        SearchResult<bool> EditOrder(int id,OrderDto order,OrderDetailDto details);
        SearchResult<bool> CancelOrder(int id); 
    }
}
