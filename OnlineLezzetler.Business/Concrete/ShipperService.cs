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

namespace OnlineLezzetler.Business.Concrete
{
    public class ShipperService : BaseAppService, IShipperService
    {
        private readonly IMapper _mapper;
        public ShipperService(OnlineLezzetlerContext context,IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public SearchResult<bool> AddShipper(ShipperDto shipper)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = (from u in _context.Shippers
                              where u.CompanyName == shipper.CompanyName
                              select u).FirstOrDefault();
                if(result == null)
                {
                    _context.Shippers.Add(_mapper.Map<Shipper>(shipper));
                    _context.SaveChanges();
                    searchResult.ResultMessage = string.Empty;
                    searchResult.ResultObject = true;
                    searchResult.ResultType = ResultType.Success;
                }
                else if(result != null && result.IsActive == false) //Shipper companies will be under the command of backoffice employees.That's why we can control them.
                {
                    result.IsActive = true;
                    result.Phone = NullValidationHelper.StringNullValidation(shipper.Phone,result.Phone);
                    _context.Shippers.Update(result);
                    _context.SaveChanges();
                    searchResult.ResultMessage = String.Empty;
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
                searchResult.ResultObject= false;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<bool> DeleteShipper(int id)
        {
            SearchResult<bool> searchResult = new();

            try
            {
                var result = _context.Shippers.Find(id);

                if(result != null)
                {
                    result.IsActive =false;
                    _context.Shippers.Update(result);
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
                searchResult.ResultType= ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<bool> EditShipper(int id, ShipperDto shipper)
        {
            SearchResult<bool> searchResult= new();

            try
            {
                var result = _context.Shippers.Find(id);

                if(result != null)
                {
                    result.CompanyName = NullValidationHelper.StringNullValidation(shipper.CompanyName,result.CompanyName);
                    result.Phone = NullValidationHelper.StringNullValidation(shipper.Phone,result.Phone);
                    _context.Shippers.Update(result);
                    _context.SaveChanges();

                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject= true;
                    searchResult.ResultType = ResultType.Success;
                }
                else
                {
                    searchResult.ResultMessage = "Not Found !";
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

        public SearchResult<ShipperDto> GetShipper(int id)
        {
            SearchResult<ShipperDto> searchResult= new();

            try
            {
                var result = (from u in _context.Shippers
                              where u.ShipperID == id && u.IsActive == true
                              select u).FirstOrDefault();

                if(result != null)
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<ShipperDto>(result);
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
                searchResult.ResultMessage= ex.Message;
                searchResult.ResultType = ResultType.Error;
            }
            return searchResult;
        }

        public SearchResult<List<ShipperDto>> GetShippers()
        {
            SearchResult<List<ShipperDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Shippers
                               where u.IsActive == true
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<ShipperDto>>(results);
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

        public SearchResult<List<ShipperDto>> SearchShipper(ShipperSearchRequest request)
        {
            SearchResult<List<ShipperDto>> searchResult = new();

            try
            {
                var results = (from u in _context.Shippers
                               where u.IsActive == true &&
                               string.IsNullOrEmpty(request.ShipperName) || u.CompanyName.Contains(request.ShipperName)
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultMessage = String.Empty;
                    searchResult.ResultObject = _mapper.Map<List<ShipperDto>>(results);
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
    }
}
