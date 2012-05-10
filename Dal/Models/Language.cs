using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Dal.Models
{
    public class Language
    {
        public string Code { get; set; }

        public Guid Description_Id { get; set; }

        public bool Supported { get; set; }
    }
}
