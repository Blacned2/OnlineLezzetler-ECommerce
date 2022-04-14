using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class RegionDto
    {
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
        public virtual CountryDto Country { get; set; }
    }
}
