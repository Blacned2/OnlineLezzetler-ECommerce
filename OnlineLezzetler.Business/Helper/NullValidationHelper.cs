using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Helper
{
    public static class NullValidationHelper
    {
        public static string StringNullValidation(string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                return param;
            }
            else
            {
                throw new Exception();
            }
        }
        public static int GreaterThanZero(int param)
        {
            if(param > 0)
            {
                return param;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
