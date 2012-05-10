using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JBSoft.Web.Helpers
{
    public class PriceAttribute : ValidationAttribute
    {
        public double MinPrice { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var price = (double)value;
            if (price < MinPrice)
            {
                return false;
            }
            double cents = price - Math.Truncate(price);
            if (cents < 0.99 || cents >= 0.995)
            {
                return false;
            }

            return true;
        }
    }
}
