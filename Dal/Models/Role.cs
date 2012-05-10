using System;

namespace JBSoft.Models
{
    public class Role : AuditModelBase
    {
		public Guid Id {get; set;}
		public string Description {get; set;}
		public bool IsSystemRole {get; set;}
		
    }
}

