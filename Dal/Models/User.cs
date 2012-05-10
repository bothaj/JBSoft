using System;

namespace JBSoft.Dal.Models
{
    public class User : Person
    {
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public string PasswordHint { get; set; }

        public string Language_Code { get; set; }

        public bool BackOfficeUser { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, Surname); }
        }

        public string Picture { get; set; }
    }
}
