using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class CityDto
    {
        public int CityID { get; set; }
        public int RegionID { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
    }
}
