using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class SupplierDto
    {
        public int SupplierID { get; set; }
        public int CityID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }
        public string? HomePage { get; set; }
    }
}
