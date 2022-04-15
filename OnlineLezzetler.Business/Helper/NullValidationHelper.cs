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
#pragma warning disable IDE0060 // Remove unused parameter
        public static void StringNullValidation(string param, string bindTo)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (!string.IsNullOrEmpty(param))
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                bindTo = param;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            }
        }

        /// <summary>Method helps to bind if param isn't <c>ZERO.</c> First param is your binding obj and second is where you bind it.</summary>
#pragma warning disable IDE0060 // Remove unused parameter
        public static void BindIfNotZero(int param,int bindTo)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if(param > 0)
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                bindTo = param;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            }
        }

        /// <summary>Method helps to bind if param isn't <c>ZERO.</c> First param is your binding obj and second is where you bind it.</summary>
#pragma warning disable IDE0060 // Remove unused parameter
        public static void BindIfNotZero(double param,double bindTo)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if(param > 0)
            {
                bindTo = param;
            } 
        }

        public static void BindDateTimeIfNotNull(DateTime param,DateTime bindTo)
        {
            if(param > bindTo)
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                bindTo = param;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            }
        }
    }
}
