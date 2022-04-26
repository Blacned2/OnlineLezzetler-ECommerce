using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IOrderDetailService
    {
        SearchResult<List<OrderDetailDto>> GetCustomerOrderDetails(int customerID);
        SearchResult<List<OrderDetailDto>> GetSupplierOrderDetails(int supplierID);
        SearchResult<OrderDetailDto> GetOrderDetail(int orderDetailID); //customer's order detail
        SearchResult<bool> AddOrderDetail(OrderDetailDto orderDetail);

    }
}
