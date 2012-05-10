using System;

namespace JBSoft.Models
{
    public class FeatureSection : AuditModelBase
    {
		public Guid Id {get; set;}
		public Guid Description_Id {get; set;}
		public string ImageUrl {get; set;}
		public int SortOrder {get; set;}
		
    }
}

