using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JBSoft.Web.Validation
{
    public class MinimumValueAttribute : ValidationAttribute
    {
        public double Min { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if ((int)value < Min)
            {
                return false;
            }

            return true;
        }
    }
}
