using System.ComponentModel.DataAnnotations;

namespace OnlineLezzetler.Data.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryShortName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}