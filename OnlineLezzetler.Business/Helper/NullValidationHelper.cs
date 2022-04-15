using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.Helper
{
    public static class NullValidationHelper
    {
        /// <summary>Method helps to bind if param isn't <c>null.</c> First param is your binding obj and second is where you bind it.</summary>
        public static void StringNullValidation(string param, string bindTo)
        {
            if (!string.IsNullOrEmpty(param))
            {
                bindTo = param;
            }
        }

        /// <summary>Method helps to bind if param isn't <c>ZERO.</c> First param is your binding obj and second is where you bind it.</summary>
        public static void BindIfNotZero(int param,int bindTo)
        {
            if(param > 0)
            {
                bindTo = param;
            }
        }

        /// <summary>Method helps to bind if param isn't <c>ZERO.</c> First param is your binding obj and second is where you bind it.</summary>
        public static void DoubleNullValidation(double param,double bindTo)
        {
            if(param > 0)
            {
                bindTo = param;
            } 
        }
    }
}
