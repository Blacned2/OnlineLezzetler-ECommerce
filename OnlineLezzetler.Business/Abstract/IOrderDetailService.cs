﻿using OnlineLezzetler.Business.AutoMapper.Dtos;
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
        SearchResult<List<OrderDetailDto>> GetOrderDetails(int id);
        SearchResult<OrderDetailDto> GetOrderDetail(int id); //Both client and supplier sees
    }
}
