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
        SearchResult<HashSet<OrderDto>> GetCustomerOrders(int id); //Customer's orders
        SearchResult<OrderDto> GetCustomerOrder(int customerID,int orderID); //Customer's single order
        SearchResult<HashSet<OrderDto>> GetSupplierOrders(int supplierID); //Supplier's orders
        SearchResult<OrderDto> GetSupplierOrder(int supplierID, int orderID); //Supplier's single order
        SearchResult<bool> NewOrder(OrderDto order); 
        SearchResult<bool> CancelOrder(int id); //If the order is 3min or below, we can cancel it
        SearchResult<bool> OrderDelivered(int id); //Order delivered
    }
}
