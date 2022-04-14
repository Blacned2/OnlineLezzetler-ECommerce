using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public int CityID { get; set; }
        public string CustomerName { get; set; }
        public string? CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("CityID")]
        public virtual City City { get; set; }
    }
}
