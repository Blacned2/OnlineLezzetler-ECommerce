using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Models
{
    public class CategorySearchRequest
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
