using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Routing;
using System.IO;
using System.Text;

namespace JBSoft.Web.Helpers
{
    public class DropDownListItem : SelectListItem
    {
        public DropDownListItem()
        {
        }

        public DropDownListItem(string text, object value, bool selected)
        {
            Text = text;
            Value = value.ToString();
            Selected = selected;
        }

        public DropDownListItem(string text, object value, bool selected, object htmlAttributes)
            : this(text, value, selected)
        {
            HtmlAttributes = htmlAttributes;
        }

        public object HtmlAttributes { get; set; }
    }

    public static class DropDownListHelper
    {
        /// <summary>
        /// Renders the dropdownlist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="items">The items.</param>
        /// <param name="itemsCallback">The items callback.</param>
        /// <returns></returns>
        public static string DropDownList<T>(this HtmlHelper helper, string name, IEnumerable<T> items, Func<T, DropDownListItem> itemsCallback)
        {
            return DropDownList(helper, name, items, itemsCallback, false);
        }

        /// <summary>
        /// Renders the dropdownlist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="items">The items.</param>
        /// <param name="itemsCallback">The items callback.</param>
        /// <param name="syncWithHiddenInput">if set to <c>true</c> [sync with hidden input].</param>
        /// <returns></returns>
        public static string DropDownList<T>(this HtmlHelper helper, string name, IEnumerable<T> items, Func<T, DropDownListItem> itemsCallback, bool syncWithHiddenInput)
        {
            return DropDownList(helper, name, items, itemsCallback, syncWithHiddenInput, true, null);
        }

        /// <summary>
        /// Renders the dropdownlist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="items">The items.</param>
        /// <param name="itemsCallback">The items callback.</param>
        /// <param name="syncWithHiddenInput">if set to <c>true</c> [sync with hidden input].</param>
        /// <param name="insertPromptField">if set to <c>true</c> [insert prompt field].</param>
        /// <param name="listHtmlAttributes">The list HTML attributes.</param>
        /// <returns></returns>
        public static string DropDownList<T>(this HtmlHelper helper, string name, IEnumerable<T> items, Func<T, DropDownListItem> itemsCallback, bool syncWithHiddenInput, bool insertPromptField, object listHtmlAttributes)
        {
            object selectedValue;
            var renderItems = RenderItems(items, itemsCallback, insertPromptField, out selectedValue);

            var writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute("id", name);
            writer.AddAttribute("name", name);
            if (syncWithHiddenInput)
            {
                writer.AddAttribute("type", "hidden");
                writer.AddAttribute("value", selectedValue.ToString());
                writer.RenderBeginTag(HtmlTextWriterTag.Input);
                writer.AddAttribute("onChange", string.Format("$('#{0}').val(this.options[this.selectedIndex].value);", name));
            }

            if (listHtmlAttributes != null)
            {
                foreach (var pair in new RouteValueDictionary(listHtmlAttributes))
                {
                    writer.AddAttribute(pair.Key, pair.Value.ToString());
                }
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Select);

            writer.Write(renderItems);

            writer.RenderEndTag();

            return writer.InnerWriter.ToString();
        }

        /// <summary>
        /// Renders the items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="itemsCallback">The items callback.</param>
        /// <param name="insertPrompt">if set to <c>true</c> [insert prompt].</param>
        /// <param name="selectedValue">The selected value.</param>
        /// <returns></returns>
        private static string RenderItems<T>(IEnumerable<T> items, Func<T, DropDownListItem> itemsCallback, bool insertPrompt, out object selectedValue)
        {
            var writer = new StringBuilder();

            selectedValue = 0;

            bool foundSelectedItem = false;
            foreach (var item in items)
            {
                var dropDownListItem = itemsCallback(item);

                writer.AppendFormat("<option value=\"{0}\"", HttpUtility.HtmlEncode(dropDownListItem.Value));
                if (dropDownListItem.Selected)
                {
                    foundSelectedItem = true;
                    selectedValue = dropDownListItem.Value;
                    writer.Append(" selected=\"selected\"");
                }
                if (dropDownListItem.HtmlAttributes != null)
                {
                    foreach (var pair in new RouteValueDictionary(dropDownListItem.HtmlAttributes))
                    {
                        writer.AppendFormat(" {0}=\"{1}\"", pair.Key, HttpUtility.HtmlEncode(pair.Value.ToString()));
                    }
                }
                writer.AppendFormat(">{0}</option>", HttpUtility.HtmlEncode(dropDownListItem.Text));
                writer.AppendLine();
            }

            if (!foundSelectedItem && insertPrompt)
            {
                return string.Format("<option value=\"\" temporary=\"true\">Click to select..</option>{0}", writer);
            }
            else
            {
                return writer.ToString();
            }
        }
    }
}
