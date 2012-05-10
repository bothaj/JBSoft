using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class RequiredIfBoolValueValidator : DataAnnotationsModelValidator<RequiredIfBoolValueAttribute>
    {
        public RequiredIfBoolValueValidator(ModelMetadata metadata, ControllerContext context, RequiredIfBoolValueAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "requiredifboolvalue",
            };

            var viewContext = (ControllerContext as ViewContext);
            string depProp = viewContext
                .ViewData
                .TemplateInfo
                .GetFullHtmlFieldId(Attribute.DependentProperty);

            rule.ValidationParameters.Add("dependentProperty", depProp);
            rule.ValidationParameters.Add("targetValue", Attribute.TargetValue.ToString());
            rule.ValidationParameters.Add("comparisonType", Attribute.ValueRule.ToString());

            return new[] { rule };
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // get a reference to the property this validation depends upon
            var field = Metadata.ContainerType.GetProperty(Attribute.DependentProperty);

            if (field != null)
            {
                // get the value of the dependent property
                bool value;
                var fieldValue = field.GetValue(container, null);
                if (fieldValue != null && Boolean.TryParse(fieldValue.ToString(), out value))
                {
                    // compare the value against the target value
                    if (Attribute.ValueRule == ValueRule.Equal && value.Equals(Attribute.TargetValue))
                    {
                        // match => means we should try validating this field
                        if (!Attribute.IsValid(Metadata.Model))
                            // validation failed - return an error
                            yield return new ModelValidationResult { Message = ErrorMessage };
                    }
                }
            }
        }
    }
}