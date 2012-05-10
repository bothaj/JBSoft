/// <reference path="jquery-1.4.1-vsdoc.js" />
/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="MicrosoftMvcAjax.debug.js" />
/// <reference path="MicrosoftMvcValidation.debug.js" />

// jQuery version of required-if validation, if that framework is loaded
if (typeof (jQuery) !== "undefined" && typeof (jQuery.validator) !== "undefined") {

    (function ($) {
        $.validator.addMethod('requiredif', function (value, element, parameters) {
            var id = '#' + parameters['dependentProperty'];

            // get the target value (as a string, as that's what actual value will be)
            var targetvalue = parameters['targetValue'];
            targetvalue = (targetvalue == null ? '' : targetvalue).toString();
            
            // get the actual value of the target control
            var actualvalue = $(id).val();

            // if the condition is true, reuse the existing required field validator functionality
            if (targetvalue === actualvalue)
                return $.validator.methods.required.call(this, value, element, parameters);

            return true;
        });

    })(jQuery);

}

// Microsoft version of required-if validation, if that framework is loaded
if (typeof (Sys) !== "undefined" && typeof (Sys.Mvc) !== "undefined" && typeof (Sys.Mvc.ValidatorRegistry) !== "undefined") {

    (function () {

        Type.registerNamespace('Sample');
        Sample.RequiredIfValidator = function RequiredIfValidator(dependentProperty, targetvalue) {
            // store the id of the property to check
            this._dependentProperty = dependentProperty;
            // store the target value (as a string, as that's what actual value will be)
            this._targetValue = (targetvalue == null ? '' : targetvalue).toString();
        }
        Sample.RequiredIfValidator.create = function create(rule) {
            // function to create a new validator from the rule parameters
            var dependentProperty = rule.ValidationParameters['dependentProperty'];
            var targetvalue = rule.ValidationParameters['targetValue'];
            var instance = new Sample.RequiredIfValidator(dependentProperty, targetvalue);
            return Function.createDelegate(instance, instance.validate);
        }
        Sample.RequiredIfValidator.prototype = {
            _dependentProperty: null,
            _targetValue: null,

            validate: function validate(value, context) {
                // get the current value of the control to check
                var actual = Sys.UI.DomElement.getElementById(this._dependentProperty);
                // note: next line isn't perfect; i.e. won't work for check box lists etc
                var actualvalue = actual.value;

                if (actualvalue === this._targetValue) {
                    // if the condition holds true, reuse the existing required validator
                    var validatorinstance = Sys.Mvc.ValidatorRegistry.validators.required();
                    return validatorinstance(value, context);
                }
                else
                    return true;
            }
        }

        Sample.RequiredIfValidator.registerClass('Sample.RequiredIfValidator');

        var validators = Sys.Mvc.ValidatorRegistry.validators;
        validators["requiredif"] = Function.createDelegate(null, Sample.RequiredIfValidator.create);

        // note: alternative, non-class based implementation follows...
        // 
        //validators["requiredif"] = Function.createDelegate(null, function (rule) {
        //    var dependentProperty = rule.ValidationParameters['dependentProperty'];
        //    var targetvalue = rule.ValidationParameters['targetValue'];
        //    return function () {
        //        var actual = Sys.UI.DomElement.getElementById(dependentProperty);
        //        var actualvalue = actual.value;
        //        if (actualvalue == targetvalue) {
        //            var validatorinstance = Sys.Mvc.ValidatorRegistry.validators.required();
        //            return validatorinstance(value, context);
        //        }
        //        else
        //            return true;
        //    }
        });

    })();
}

