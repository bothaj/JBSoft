using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Web.Mvc;

namespace JBSoft.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Returns a file input element by using the specified HTML helper and the name of the form field.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field and the <see cref="name">System.Web.Mvc.ViewDataDictionary</see> key that is used to look up the validation errors.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static string FileInputBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.FileInputBox(name, (object)null);
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field and the <see cref="name">System.Web.Mvc.ViewDataDictionary</see> key that is used to look up the validation errors.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static string FileInputBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return htmlHelper.FileInputBox(name, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name of the form field and the <see cref="name">System.Web.Mvc.ViewDataDictionary</see> key that is used to look up the validation errors.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>An input element that has its type attribute set to "file".</returns>
        public static string FileInputBox(this HtmlHelper htmlHelper, string name, IDictionary<String, Object> htmlAttributes)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("type", "file", true);
            tagBuilder.MergeAttribute("name", name, true);
            tagBuilder.GenerateId(name);

            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }

        /// <summary>
        /// Returns a label element by using the specified HTML helper, the name of the target element, and the text of the label.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="target">The associated target element. This attribute explicitly associates the label being defined with another element.</param>
        /// <param name="text">The text of the label</param>
        /// <returns>A label element.</returns>
        public static string Label(this HtmlHelper htmlHelper, string target, string text)
        {
            return htmlHelper.Label(target, text, (object)null);
        }

        /// <summary>
        /// Returns a label element by using the specified HTML helper, the name of the target element, the text of the label, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="target">The associated target element. This attribute explicitly associates the label being defined with another element.</param>
        /// <param name="text">The text of the label</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>A label element.</returns>
        public static string Label(this HtmlHelper htmlHelper, string target, string text, object htmlAttributes)
        {
            return htmlHelper.Label(target, text, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression,
           string labelText, object htmlAttributes) where TModel : class
        {
            TagBuilder builder = new TagBuilder("label");
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes)); // to convert an object into an IDictionary
            string value = ExpressionHelper.GetExpressionText(expression); ;
            builder.InnerHtml = labelText;
            //the replaces shouldnt be necessary in the next statement, but there is a bug in the MVC framework that makes them necessary.
            builder.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(value).Replace('[', '_').Replace(']', '_'));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Returns a label element by using the specified HTML helper, the name of the target element, the text of the label, and the HTML attributes.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="target">The associated target element. This attribute explicitly associates the label being defined with another element.</param>
        /// <param name="text">The text of the label</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <returns>A label element.</returns>
        public static string Label(this HtmlHelper htmlHelper, string target, string text, IDictionary<String, Object> htmlAttributes)
        {
            var tagBuilder = new TagBuilder("label");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("for", target, true);
            tagBuilder.SetInnerText(text);

            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return LabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object htmlAttributes)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tagBuilder.MergeAttribute("href", string.Format("../{0}/{1}", controllerName, actionName), true);
            tagBuilder.SetInnerText(linkText);

            TagBuilder imageTagBuilder = null;

            imageTagBuilder = new TagBuilder("span");

            return tagBuilder.ToString(TagRenderMode.StartTag) + imageTagBuilder.ToString(TagRenderMode.StartTag) + linkText + imageTagBuilder.ToString(TagRenderMode.EndTag) + tagBuilder.ToString(TagRenderMode.EndTag);
        }

        public static string Button(this HtmlHelper htmlHelper, string name, string src, string text)
        {
            return htmlHelper.Button(name, src, text, (object)null);
        }

        public static string Button(this HtmlHelper htmlHelper, string name, string src, string text, object htmlAttributes)
        {
            return htmlHelper.Button(name, src, text, new RouteValueDictionary(htmlAttributes));
        }

        public static string Button(this HtmlHelper htmlHelper, string name, string src, string text, IDictionary<String, Object> htmlAttributes)
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", name, true);
            tagBuilder.MergeAttribute("title", name, true);
            tagBuilder.MergeAttribute("type", "button", true);
            tagBuilder.GenerateId(name);

            TagBuilder imageTagBuilder = null;

            if (!String.IsNullOrEmpty(src))
            {
                imageTagBuilder = new TagBuilder("img");
                imageTagBuilder.MergeAttribute("src", src, true);

                imageTagBuilder.MergeAttribute("alt", !String.IsNullOrEmpty(text) ? text : name, true);
            }

            return tagBuilder.ToString(TagRenderMode.StartTag) + (imageTagBuilder != null ? imageTagBuilder.ToString(TagRenderMode.SelfClosing) : String.Empty) + " " + text + tagBuilder.ToString(TagRenderMode.EndTag);
        }

        public static string ImageLink(this HtmlHelper htmlHelper, string name, string title, string controller, string actionName, object routeValues, string src, IDictionary<String, Object> htmlAttributes)
        {
            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", name, true);
            tagBuilder.MergeAttribute("alt", title, true);
            tagBuilder.MergeAttribute("title", title, true);
            tagBuilder.MergeAttribute("href", string.Format("{0}/{1}/{2}", controller, actionName, routeValues), true);
            tagBuilder.GenerateId(name);

            TagBuilder imageTagBuilder = null;

            if (!String.IsNullOrEmpty(src))
            {
                imageTagBuilder = new TagBuilder("img");
                imageTagBuilder.MergeAttribute("src", src, true);

            }

            return tagBuilder.ToString(TagRenderMode.StartTag) + (imageTagBuilder != null ? imageTagBuilder.ToString(TagRenderMode.SelfClosing) : String.Empty) + tagBuilder.ToString(TagRenderMode.EndTag);
        }

        /// <summary>
        /// A Simple ActionLink Image
        /// </summary>
        /// <param name="actionName">name of the action in controller</param>
        /// <param name="imgUrl">url of the image</param>
        /// <param name="alt">alt text of the image</param>
        /// <returns></returns>
        public static string ImageLink(this HtmlHelper helper, string actionName, string imgUrl, string alt)
        {
            return ImageLink(helper, actionName, imgUrl, alt, null, null, null);
        }

        /// <summary>
        /// A Simple ActionLink Image
        /// </summary>
        /// <param name="actionName">name of the action in controller</param>
        /// <param name="imgUrl">url of the iamge</param>
        /// <param name="alt">alt text of the image</param>
        /// <returns></returns>
        public static string ImageLink(this HtmlHelper helper, string actionName, string imgUrl, string alt, object routeValues)
        {
            return ImageLink(helper, actionName, imgUrl, alt, routeValues, null, null);
        }

        /// <summary>
        /// A Simple ActionLink Image
        /// </summary>
        /// <param name="actioNName">name of the action in controller</param>
        /// <param name="imgUrl">url of the image</param>
        /// <param name="alt">alt text of the image</param>
        /// <param name="linkHtmlAttributes">attributes for the link</param>
        /// <param name="imageHtmlAttributes">attributes for the image</param>
        /// <returns></returns>
        public static string ImageLink(this HtmlHelper helper, string actioNName, string imgUrl, string alt, object routeValues, object linkHtmlAttributes, object imageHtmlAttributes)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(actioNName, routeValues);

            //Create the link
            var linkTagBuilder = new TagBuilder("a");
            linkTagBuilder.MergeAttribute("href", url);
            linkTagBuilder.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));

            //Create image
            var imageTagBuilder = new TagBuilder("img");
            imageTagBuilder.MergeAttribute("src", urlHelper.Content(imgUrl));
            imageTagBuilder.MergeAttribute("alt", urlHelper.Content(alt));
            imageTagBuilder.MergeAttributes(new RouteValueDictionary(imageHtmlAttributes));

            //Add image to link
            linkTagBuilder.InnerHtml = imageTagBuilder.ToString(TagRenderMode.SelfClosing);

            return linkTagBuilder.ToString();
        }




        public static string YesNoImage(this HtmlHelper htmlHelper, string alt, bool showYesImage)
        {
            if (showYesImage)
                return "<img border='none' title='" + alt + "' alt='" + alt + "' src='Images/Icons/Check.png' />";

            return "<img border='none' title='" + alt + "' alt='" + alt + "' src='Images/Icons/Uncheck.png' />";
        }
    }
}
