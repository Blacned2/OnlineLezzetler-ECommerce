using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IOrderService
    {
        SearchResult<List<OrderDto>> GetOrders();
        SearchResult<OrderDto> GetOrder(int id);
        SearchResult<bool> NewOrder(OrderDto order);
        SearchResult<bool> EditOrder(int id,OrderDto order);
        SearchResult<bool> CancelOrder(int id); 
    }
}
