using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;

namespace JBSoft.Web.Helpers
{
    public static class DisplayBoxHelper
    {
        /// <summary>
        /// Renders the displaybox
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="displayInputId">The display input id.</param>
        /// <returns></returns>
        public static string DisplayBox(this HtmlHelper helper, string name, string displayInputId)
        {
            return DisplayBox(helper, name, displayInputId, null);
        }

        /// <summary>
        /// Renders the displaybox
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="displayInputId">The display input id.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string DisplayBox(this HtmlHelper helper, string name, string displayInputId, object value)
        {
            var writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute("type", "hidden");
            writer.AddAttribute("id", name);
            writer.AddAttribute("name", name);
            if (value != null)
            {
                writer.AddAttribute("value", value.ToString());
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Input);

            writer.AddAttribute("type", "text");
            writer.AddAttribute("id", displayInputId);
            writer.AddAttribute("onChange", string.Format("$('#{0}').val(this.value);", name));
            writer.AddAttribute("disabled", "disabled");
            if (value != null)
            {
                writer.AddAttribute("value", value.ToString());
            }
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Input);

            return writer.InnerWriter.ToString();
        }
    }
}
