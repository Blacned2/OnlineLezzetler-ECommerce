using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public int ShipperID { get; set; }
        public int ShippedCityID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedTime { get; set; }
        public float Freight { get; set; }
    }
}
