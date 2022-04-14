using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [ForeignKey("CityID")]
        public int EmployeeCityID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiredDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Notes { get; set; }
        public string? PhotoPath { get; set; }
        public bool IsFired { get; set; } = false;
         
        public virtual City City { get; set; }

    }
}
