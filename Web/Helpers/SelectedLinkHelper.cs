using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace JBSoft.Web.Helpers
{
    public static class SelectedLinkHelper
    {
        public static string SelectedLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, bool selected)
        {
            if (selected)
            {
                return string.Format("<span>{0}</span>", linkText);
            }
            else
            {
                return helper.ActionLink(linkText, actionName, controllerName).ToString();
            }
        }
    }
}
