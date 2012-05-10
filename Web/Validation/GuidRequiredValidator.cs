using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class GuidRequiredValidator : DataAnnotationsModelValidator<GuidRequiredAttribute>
    {
        string _message;

        public GuidRequiredValidator(ModelMetadata metadata, ControllerContext context,
            GuidRequiredAttribute attribute)
            : base(metadata, context, attribute) 
        {
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            var rule = new ModelClientValidationRule {
                ErrorMessage = _message,
                ValidationType = "guidRequired"
            };

            return new[] { rule };
        }
    }
}
