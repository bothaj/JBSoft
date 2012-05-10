using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Dal.Models
{
    public class UserGroup
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Currency_Code { get; set; } 

        public DescriptionIdPair<Guid>[] Modules { get; set; }

        public bool BackOfficeGroup { get; set; }
    }
}
