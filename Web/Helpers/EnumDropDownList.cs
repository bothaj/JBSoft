using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace JBSoft.Web.Helpers
{
    public static class EnumDropDownList
    { 
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownList.EnumDropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            IEnumerable<SelectListItem> items =
                values.Select(value => new SelectListItem
                {
                    Text = value.ToString().Replace("_", " "),
                    Value = value.ToString(),
                    Selected = value.Equals(metadata.Model)
                });

            if (htmlAttributes != null)
                return htmlHelper.DropDownListFor(
                    expression,
                    items,
                    htmlAttributes
                    );
            else
                return htmlHelper.DropDownListFor(
                    expression,
                    items
                    );
        }
    }
}
