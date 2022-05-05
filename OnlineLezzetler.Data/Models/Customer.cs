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
        [Required]
        public string CustomerName { get; set; }
#nullable enable
        public string? CompanyName { get; set; }
        public string? Fax { get; set; }
#nullable disable
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; } 

        [ForeignKey("CityID")]
        public virtual City City { get; set; }
    }
}
