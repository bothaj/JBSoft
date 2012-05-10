using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class BooleanRequiredValidator : DataAnnotationsModelValidator<BooleanRequiredAttribute> 
    {
        string _message;

        public BooleanRequiredValidator(ModelMetadata metadata, ControllerContext context, 
            BooleanRequiredAttribute attribute)
            : base(metadata, context, attribute) {}

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            var rule = new ModelClientValidationRule {
                ErrorMessage = this.ErrorMessage,
                ValidationType = "booleanRequired"
            };

            rule.ValidationParameters.Add("required", true);

            return new[] { rule };
        }
    }
}
