using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public int RegionID { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("RegionID")]
        public virtual Region Region { get; set; }
    }
}
