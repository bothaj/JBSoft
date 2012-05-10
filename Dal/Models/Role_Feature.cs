using System;

namespace JBSoft.Models
{
    public class Role_Feature : AuditModelBase
    {
		public Guid Role_Id {get; set;}
		public Guid Feature_Id {get; set;}
		
    }
}

