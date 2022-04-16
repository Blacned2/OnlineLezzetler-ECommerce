using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class ShipperDto
    {
        public int ShipperID { get; set; } 
        public string CompanyName { get; set; } 
        public string Phone { get; set; }
    }
}
