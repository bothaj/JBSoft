using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangent.Web.Helpers
{
    public static class ModalHelpers
    {
        public static string ActionLinkToModal(
            this System.Web.Mvc.HtmlHelper html,
            string partialName,
            string controllerName,
            string linkText)
        {
            var link = html.ActionLink(
                linkText,
                partialName, //action
                controllerName, //controller 
                new { id = partialName + "_colorbox", @class = "colorbox" }); //here's the new id 

            return link;
        } 
    }
}
