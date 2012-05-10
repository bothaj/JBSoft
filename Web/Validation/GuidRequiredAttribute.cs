using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JBSoft.Web.Validation
{
    public class GuidRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is Guid)
            {
                if ((Guid)value == Guid.Empty)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
