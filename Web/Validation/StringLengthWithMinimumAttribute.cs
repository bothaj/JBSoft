using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JBSoft.Web.Validation
{
    public class StringLengthWithMinimumAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public StringLengthWithMinimumAttribute(int _minLength, int _maxLength)
        {
            this.MinLength = _minLength;
            this.MaxLength = _maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.ToString().Length < MinLength || value.ToString().Length > MaxLength)
            {
                return false;
            }

            return true;
        }
    }
}
