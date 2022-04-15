using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public int EmployeeCityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiredDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
#nullable enable
        public string? Notes { get; set; }
        public string? PhotoPath { get; set; }
#nullable disable
    }
}
