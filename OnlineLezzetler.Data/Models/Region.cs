using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLezzetler.Data.Models
{
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        public int CountryID { get; set; }
        public string RegionDescription { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
    }
}