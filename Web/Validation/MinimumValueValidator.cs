using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class MinimumValueValidator : DataAnnotationsModelValidator<MinimumValueAttribute> {

        double _minPrice;
        string _message;

        public MinimumValueValidator(ModelMetadata metadata, ControllerContext context
            , MinimumValueAttribute attribute)
            : base(metadata, context, attribute) {
            _minPrice = attribute.Min;
            _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {
            var rule = new ModelClientValidationRule {
                ErrorMessage = _message,
                ValidationType = "price"
            };
            rule.ValidationParameters.Add("min", _minPrice);

            return new[] { rule };
        }
    }
}