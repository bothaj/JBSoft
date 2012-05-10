using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class RequiredIfManyValidator : DataAnnotationsModelValidator<RequiredIfManyAttribute>
    {
        public RequiredIfManyValidator(ModelMetadata metadata, ControllerContext context, RequiredIfManyAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "requiredifmany",
            };

            var viewContext = (ControllerContext as ViewContext);

            string depProp = viewContext
                .ViewData
                .TemplateInfo
                .GetFullHtmlFieldId(Attribute.DependentProperty);

            rule.ValidationParameters.Add("dependentProperty", depProp);
            rule.ValidationParameters.Add("targetValues", Attribute.TargetValue);
            

            return new [] { rule };
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            var field = Metadata.ContainerType.GetProperty(Attribute.DependentProperty);

            if (field != null)
            {
                // get the value of the dependent property
                var value = field.GetValue(container, null);

                // compare the value against the target value
                if ((value == null && Attribute.TargetValue != null))
                {
                    foreach (var targetValue in Attribute.TargetValue)
                    {
                        if (value.Equals(Attribute.TargetValue))
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
}