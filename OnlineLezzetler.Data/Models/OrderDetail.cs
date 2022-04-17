using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class OrderDetail
    {
        [Key]
        public int DetailID { get; set; } 
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; } 
    }
}
