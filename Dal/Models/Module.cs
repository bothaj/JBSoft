using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Dal.Models
{
    public class Module
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string BillingCode { get; set; }
    }
}
