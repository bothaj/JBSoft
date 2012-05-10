using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JBSoft.Web.Validation
{
    public class StringLengthWithMinimumValidator : DataAnnotationsModelValidator<StringLengthWithMinimumAttribute> 
    {
        int _minLength;
        int _maxLength;
        string _message;

        public StringLengthWithMinimumValidator(ModelMetadata metadata, ControllerContext context
            , StringLengthWithMinimumAttribute attribute)
            : base(metadata, context, attribute) {
                _minLength = attribute.MinLength;
                _maxLength = attribute.MaxLength;
                _message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules() {

            var rule = new ModelClientValidationRule {
                ErrorMessage = _message,
                ValidationType = "stringminlength"
            };

            rule.ValidationParameters.Add("minlength", _minLength);
            rule.ValidationParameters.Add("maxlength", _maxLength);

            return new[] { rule };
        }


    }
}
