using System;
using System.Collections.Generic;
using OnlineLezzetler.Business.Models;

namespace OnlineLezzetler.Business.Abstract
{
    public interface IDasboardService
    {
        SearchResult<int> DailyOrderRate(int supplierID);
        SearchResult<List<YearlyIncome>> YearlyIncome(int supplierID);
        //TODO
    }
}
