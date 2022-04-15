using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Models
{
    public class SupplierSearchRequest
    {
#nullable enable
        public string? CityName { get; set; }
        public string? CompanyName { get; set; }
#nullable disable
    }
}
