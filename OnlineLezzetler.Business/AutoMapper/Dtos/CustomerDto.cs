using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public int CityID { get; set; }
        public string CustomerName { get; set; }
#nullable enable
        public string? CompanyName { get; set; }
        public string? Fax { get; set; }
#nullable disable
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
