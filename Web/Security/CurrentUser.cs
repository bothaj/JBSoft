using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace JBSoft.Web.Security
{
    public class CurrentUser
    {
        /// <summary>
        /// Get the Logged in Users UserId
        /// </summary>
        public static Guid UserId
        {
            get
            {
                try
                {
                    var user = HttpContext.Current.User as UserPrincipal;
                    if (user != null)
                        return user.User_Id;

                    return new Guid();
                }
                catch
                {
                    return new Guid("00000000-0000-0000-0000-000000000000");
                }
            }
        }
        
        public static string Name { get; set; }
    }
}
