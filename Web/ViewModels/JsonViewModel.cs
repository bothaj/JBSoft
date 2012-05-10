using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Web.ViewModels
{
    public class JsonViewModel
    {
        public string Result { get; set; }

        public bool HasErrors { get; set; }

        public string Message { get; set; }

        public bool IsValid { get; set; }

        public string Html { get; set; }

    }
}
