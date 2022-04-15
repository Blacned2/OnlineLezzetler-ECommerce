using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public int CityID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
#nullable enable
        public string? Fax { get; set; }
        public string? HomePage { get; set; }
#nullable disable
        public bool IsActive { get; set; } = true;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GUID { get; set; }

        [ForeignKey("CityID")]
        public virtual City City { get; set; }

        public Supplier()
        {
            GUID = Guid.NewGuid();
        }
    }
}
