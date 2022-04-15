using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Models
{
    public class EmployeeSearchRequest
    {
#nullable enable
        public string? EmployeeName { get; set; }
        public string? EmployeeCityName { get; set; }
#nullable disable
    }
}
