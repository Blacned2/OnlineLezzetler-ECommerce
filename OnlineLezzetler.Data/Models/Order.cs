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

        [ForeignKey("CustomerID")]
        public int? CustomerID { get; set; }
        [ForeignKey("DetailID")]
        public int DetailID { get; set; }

        [ForeignKey("ShipperID")]
        public int? ShipperID { get; set; }  

        [ForeignKey("CityID")]
        public int? ShippedCityID{ get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; } 
        public bool IsCancelled { get; set; } = false;
        public bool IsDelivered { get; set; } = false;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GUID { get; set; } 
        public virtual Customer Customer { get; set; }
        public virtual City City { get; set; } 
        public virtual Shipper Shipper { get; set; } 
        public virtual OrderDetail OrderDetail { get; set; }
         
        public Order()
        {
            OrderDate = DateTime.Now;
            RequiredDate = DateTime.Now.AddMinutes(45); //Maximum 45 min to deliver
            GUID = Guid.NewGuid();
        }
    }
}
