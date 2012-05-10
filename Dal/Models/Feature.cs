using System;

namespace JBSoft.Models
{
    public class Feature : AuditModelBase
    {
		public Guid Id {get; set;}

		public Guid Module_Id {get; set;}

		public Guid Description_Id {get; set;}

        public string Description { get; set; }

		public Guid FeatureSection_Id {get; set;}
		
    }
}

