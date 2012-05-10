using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class RequiredifManyRegexValidator : DataAnnotationsModelValidator<RequiredifManyRegexAttribute> 
    {
        string _checkValue;
        string _message;

        public RequiredifManyRegexValidator(ModelMetadata metadata, ControllerContext context
            , RequiredifManyRegexAttribute attribute)
            : base(metadata, context, attribute) {

            _checkValue = attribute.CheckValue;
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            
            var rule = new ModelClientValidationRule {
                ErrorMessage = _message,
                ValidationType = "requiredifmanyregex"
            };

            var viewContext = (ControllerContext as ViewContext);
            string depProp = viewContext
                .ViewData
                .TemplateInfo
                .GetFullHtmlFieldId(Attribute.DependentProperty);

            rule.ValidationParameters.Add("dependentProperty", depProp);
            rule.ValidationParameters.Add("targetValues", Attribute.TargetValues);
            rule.ValidationParameters.Add("regexCheck", _checkValue);

            return new[] { rule };
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // get a reference to the property this validation depends upon
            var field = Metadata.ContainerType.GetProperty(Attribute.DependentProperty);

            if (field != null)
            {
                // get the value of the dependent property
                var value = field.GetValue(container, null);

                // compare the value against the target value
                if (value == null && Attribute.TargetValues != null)
                {
                    foreach (var arrayValue in Attribute.TargetValues)
                    {
                        if (value.Equals(arrayValue))
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
