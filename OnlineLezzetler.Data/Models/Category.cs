using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
