using System;
using JBSoft.Models;

namespace JBSoft.Dal.Models
{
    public class Person : AuditModelBase
    {
        #region Public Members

        public Guid Id { get; set; }

        public Guid UserGroup_Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string PhoneOffice { get; set; }

        public string Fax { get; set; }

        public string Description { get; set; }

        public short Gender { get; set; }

        public bool Disability { get; set; }

        public string DisabilityNote { get; set; }

        public string PreferredName { get; set; }

        #endregion
    }
}
