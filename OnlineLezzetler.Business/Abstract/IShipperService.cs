using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IShipperService
    {
        SearchResult<List<ShipperDto>> GetShippers();
        SearchResult<ShipperDto> GetShipper(int id);
        SearchResult<bool> DeleteShipper(int id);
        SearchResult<bool> AddShipper(ShipperDto shipper);
        SearchResult<bool> EditShipper(int id,ShipperDto shipper);
        SearchResult<List<ShipperDto>> SearchShipper(ShipperSearchRequest request);

    }
}
