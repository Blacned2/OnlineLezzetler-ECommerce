using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("EmployeeID")]
        public int? EmployeeID { get; set; }

        [ForeignKey("CustomerID")]
        public int? CustomerID { get; set; } 

        [ForeignKey("ShipperID")]
        public int? ShipperID { get; set; }  

        [ForeignKey("CityID")]
        public int? ShippedCityID{ get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public float Freight { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GUID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual City City { get; set; } 
        public virtual Shipper Shipper { get; set; } 
         
        public Order()
        {
            OrderDate = DateTime.Now;
            GUID = Guid.NewGuid();
        }
    }
}
