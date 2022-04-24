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
        public static string StringNullValidation(string param, string bindTo)
        {
            if (!string.IsNullOrEmpty(param))
            {
                return param;
            }
            else
            {
                return bindTo;
            }
        }

        /// <summary>Method helps to bind if param isn't <c>ZERO.</c> First param is your binding obj and second is where you bind it.</summary>
        public static int BindIfNotZero(int param, int bindTo)
        {
            if (param > 0)
            {
                return param;
            }
            else
            {
                return bindTo;
            }
        }

        /// <summary>Method helps to bind if param isn't <c>ZERO.</c> First param is your binding obj and second is where you bind it.</summary>
        public static double BindIfNotZero(double param, double bindTo)
        {
            if (param > 0)
            {
                return param;
            }
            else
            {
                return bindTo;
            }
        }

        public static DateTime BindDateTimeIfNotNull(DateTime param, DateTime bindTo)
        {
            if (param > bindTo)
            {
                return param;
            }
            else
            {
                return bindTo;
            }
        }
    }
}
