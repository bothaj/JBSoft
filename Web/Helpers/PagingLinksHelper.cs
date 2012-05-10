using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.IO;
using System.Text;

namespace JBSoft.Web.Helpers
{
    public static class PagingLinksHelper
    {
        /// <summary>
        /// Renders the paging links
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <param name="previousPageExists">if set to <c>true</c> [previous page exists].</param>
        /// <param name="nextPageExists">if set to <c>true</c> [next page exists].</param>
        /// <param name="action">The action.</param>
        /// <param name="linkParameters">The link parameters.</param>
        /// <returns></returns>
        public static string PagingLinks(this HtmlHelper helper, int currentPageIndex, bool previousPageExists, bool nextPageExists, string action, Func<int, object> linkParameters)
        {
            var writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute("class", "pager");
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            if (previousPageExists)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Href, CreateLink(currentPageIndex - 1, action, linkParameters), true);
                writer.RenderBeginTag(HtmlTextWriterTag.A);
            }
            else
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Strong);
            }
            writer.Write("Previous");
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            writer.RenderBeginTag(HtmlTextWriterTag.Strong);
            writer.Write(currentPageIndex + 1);
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            if (nextPageExists)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Href, CreateLink(currentPageIndex + 1, action, linkParameters), true);
                writer.RenderBeginTag(HtmlTextWriterTag.A);
            }
            else
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Strong);
            }
            writer.Write("Next");
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderEndTag(); // </ul>

            return writer.InnerWriter.ToString();
        }

        /// <summary>
        /// Creates the link.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="action">The action.</param>
        /// <param name="linkParameters">The link parameters.</param>
        /// <returns></returns>
        private static string CreateLink(int i, string action, Func<int, object> linkParameters)
        {
            var link = new StringBuilder(action);
            if (linkParameters != null)
            {
                link.Append("?");
                var first = true;
                foreach (var pair in new RouteValueDictionary(linkParameters(i)))
                {
                    if (!first)
                    {
                        link.Append("&");
                    }
                    link.AppendFormat("{0}={1}", pair.Key, pair.Value);
                    first = false;
                }
            }
            return link.ToString();
        }
    }
}
