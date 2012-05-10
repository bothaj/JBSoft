using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JBSoft.Web.Validation
{
    public class RequiredIfValueAttribute: ValidationAttribute
    {
        // Note: we don't inherit from RequiredAttribute as some elements of the MVC
        // framework specifically look for it and choose not to add a RequiredValidator
        // for non-nullable fields if one is found. This would be invalid if we inherited
        // from it as obviously our RequiredIf only applies if a condition is satisfied.
        // Therefore we're using a private instance of one just so we can reuse the IsValid
        // logic, and don't need to rewrite it.
        private RequiredAttribute innerAttribute = new RequiredAttribute();
        public string DependentProperty { get; set; }
        public int TargetValue { get; set; }
        public ValueRule ValueRule { get; set; }

        public RequiredIfValueAttribute(string dependentProperty, int targetValue, ValueRule valueRule)
        {
            this.DependentProperty = dependentProperty;
            this.TargetValue = targetValue;
            this.ValueRule = valueRule;
        }

        public override bool IsValid(object value)
        {
            return innerAttribute.IsValid(value);
        }
    }

    /// <summary>
    /// Value comparison rules which are used in the validator.
    /// </summary>
    public enum ValueRule
    {
        GreaterThan = 0,
        LessThan,
        Equal
    }
}
