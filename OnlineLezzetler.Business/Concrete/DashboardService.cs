using System;
using System.Collections.Generic;
using OnlineLezzetler.Business.Abstract;
using OnlineLezzetler.Business.Models;
using OnlineLezzetler.Data;
using System.Linq;

namespace OnlineLezzetler.Business.Concrete
{
    public class DashboardService : BaseAppService, IDasboardService
    {
        public DashboardService(OnlineLezzetlerContext context) : base(context)
        {
        }

        public SearchResult<int> DailyOrderRate(int supplierID)
        {
            SearchResult<int> searchResult = new();

            try
            {
                var results = (from s in _context.Suppliers
                              join p in _context.Products
                              on s.SupplierID equals p.SupplierID
                              join od in _context.OrderDetails
                              on p.ProductID equals od.ProductID
                              join o in _context.Orders
                              on od.DetailID equals o.DetailID
                              where s.SupplierID == supplierID
                              select o).ToList();

                if (results.Any())
                {
                    searchResult.ResultObject = results.Count();
                    searchResult.ResultType = ResultType.Success;
                    searchResult.ResultMessage = string.Empty;
                }
                else
                {
                    searchResult.ResultMessage = "Not found !";
                    searchResult.ResultType = ResultType.Warning;
                }

            }
            catch (Exception ex)
            {
                searchResult.ResultType = ResultType.Error;
                searchResult.ResultMessage = ex.Message;
            }
            return searchResult;
        }

        public SearchResult<List<YearlyIncome>> YearlyIncome(int supplierID)
        {
            throw new NotImplementedException();
        }
    }
}
