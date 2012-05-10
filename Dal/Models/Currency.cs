using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Dal.Models
{
    public class Currency
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public bool Supported { get; set; }
    }
}
