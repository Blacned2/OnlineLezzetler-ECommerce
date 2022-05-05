using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Models
{
    public class ProductSearchRequest
    {
#nullable enable
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
#nullable disable
    }
}
