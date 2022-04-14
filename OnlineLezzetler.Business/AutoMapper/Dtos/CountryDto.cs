using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Dtos
{
    public class CountryDto
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryShortName
        {
            get { return CountryName; }
            set { CountryName = value.ToLower(); }    
        }
    }
}
