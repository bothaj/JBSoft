using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace JBSoft.Web.Validation
{
    public class RequiredifRegexAttribute : ValidationAttribute
    {
        // Note: we don't inherit from RequiredAttribute as some elements of the MVC
        // framework specifically look for it and choose not to add a RequiredValidator
        // for non-nullable fields if one is found. This would be invalid if we inherited
        // from it as obviously our RequiredIf only applies if a condition is satisfied.
        // Therefore we're using a private instance of one just so we can reuse the IsValid
        // logic, and don't need to rewrite it.
        public string DependentProperty { get; set; }
        public string CheckValue { get; set; }
        public object TargetValue { get; set; }

        public RequiredifRegexAttribute(string dependentProperty, string targetValue, string checkValue)
        {
            this.DependentProperty = dependentProperty;
            this.TargetValue = targetValue;
            this.CheckValue = checkValue;
        }


        public override bool IsValid(object value)
        {

            var regex = new Regex(this.CheckValue);
            return !regex.IsMatch(value.ToString());
        }
    }
}
