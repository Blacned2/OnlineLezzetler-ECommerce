using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Models
{
    public class RegionSearchRequest
    {
#nullable enable
        public string? RegionName { get; set; }
        public string? CountryName { get; set; }
        public int? CountryID { get; set; }
#nullable disable
    }
}
