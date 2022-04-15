using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Models
{
    public class CitySearchRequest
    {
#nullable enable
        public string? CityName { get; set; }
        public string? PostalCode { get; set; }
        public string? RegionDescription { get; set; }
#nullable disable
    }
}
