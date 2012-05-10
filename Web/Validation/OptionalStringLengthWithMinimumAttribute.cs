using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JBSoft.Web.Validation
{
    public class OptionalStringLengthWithMinimumAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public OptionalStringLengthWithMinimumAttribute(int _minLength, int _maxLength)
        {
            this.MinLength = _minLength;
            this.MaxLength = _maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().Length == 0)
            {
                return true;
            }

            if (value.ToString().Length < MinLength || value.ToString().Length > MaxLength)
            {
                return false;
            }

            return true;
        }
    }
}
