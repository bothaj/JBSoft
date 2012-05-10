using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.IO;

namespace JBSoft.Web.Helpers
{
    public static class RadioButtonHelper
    {
        /// <summary>
        /// Renders the RadioButton
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="displayText">The display text.</param>
        /// <param name="radioButtonName">Name of the radio button.</param>
        /// <param name="radioButtonValue">The radio button value.</param>
        /// <param name="radioButtonId">The radio button id.</param>
        /// <param name="radioButtonIsChecked">if set to <c>true</c> [radio button is checked].</param>
        /// <returns></returns>
        public static string RadioButton(this HtmlHelper helper, string displayText, string radioButtonName, object radioButtonValue, string radioButtonId, bool radioButtonIsChecked)
        {
            return RadioButton(helper, displayText, radioButtonName, radioButtonValue, radioButtonId, radioButtonIsChecked, new RouteValueDictionary());
        }

        /// <summary>
        /// Renders the RadioButton
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="displayText">The display text.</param>
        /// <param name="radioButtonName">Name of the radio button.</param>
        /// <param name="radioButtonValue">The radio button value.</param>
        /// <param name="radioButtonId">The radio button id.</param>
        /// <param name="radioButtonIsChecked">if set to <c>true</c> [radio button is checked].</param>
        /// <param name="radioButtonHtmlAttributes">The radio button HTML attributes.</param>
        /// <returns></returns>
        public static string RadioButton(this HtmlHelper helper, string displayText, string radioButtonName, object radioButtonValue, string radioButtonId, bool radioButtonIsChecked, object radioButtonHtmlAttributes)
        {
            return RadioButton(helper, displayText, radioButtonName, radioButtonValue, radioButtonId, radioButtonIsChecked, new RouteValueDictionary(radioButtonHtmlAttributes));
        }

        /// <summary>
        /// Renders the RadioButton
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="displayText">The display text.</param>
        /// <param name="radioButtonName">Name of the radio button.</param>
        /// <param name="radioButtonValue">The radio button value.</param>
        /// <param name="radioButtonId">The radio button id.</param>
        /// <param name="radioButtonIsChecked">if set to <c>true</c> [radio button is checked].</param>
        /// <param name="radioButtonHtmlAttributes">The radio button HTML attributes.</param>
        /// <returns></returns>
        public static string RadioButton(this HtmlHelper helper, string displayText, string radioButtonName, object radioButtonValue, string radioButtonId, bool radioButtonIsChecked, IDictionary<string, object> radioButtonHtmlAttributes)
        {
            var writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute("for", radioButtonId);
            writer.RenderBeginTag(HtmlTextWriterTag.Label);

            writer.AddAttribute("type", "radio");
            writer.AddAttribute("id", radioButtonId);
            writer.AddAttribute("name", radioButtonName);
            writer.AddAttribute("value", radioButtonValue.ToString());

            if (radioButtonIsChecked)
            {
                writer.AddAttribute("checked", "checked");
            }

            foreach (var pair in radioButtonHtmlAttributes)
            {
                writer.AddAttribute(pair.Key, pair.Value.ToString());
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Input);

            writer.RenderEndTag();

            writer.WriteEncodedText(displayText);

            writer.RenderEndTag();

            return writer.InnerWriter.ToString();
        }
    }
}
