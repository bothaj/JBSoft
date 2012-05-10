using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class RequiredIfHasValueValidator : DataAnnotationsModelValidator<RequiredIfHasValueAttribute>
    {
        public RequiredIfHasValueValidator(ModelMetadata metadata, ControllerContext context, RequiredIfHasValueAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "requiredifhasvalue",
            };

            var viewContext = (ControllerContext as ViewContext);
            string depProp = viewContext
                .ViewData
                .TemplateInfo
                .GetFullHtmlFieldId(Attribute.DependentProperty);

            rule.ValidationParameters.Add("dependentProperty", depProp);

            return new[] { rule };
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // get a reference to the property this validation depends upon
            var field = Metadata.ContainerType.GetProperty(Attribute.DependentProperty);

            if (field != null)
            {
                // get the dependent property
                var fieldValue = field.GetValue(container, null);

                if (fieldValue != null && fieldValue.ToString().Length > 0)
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