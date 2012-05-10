using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Dal.ResultHelpers
{
    public interface IResult
    {
        List<EntityError> EntityErrors { get; }

        bool Success { get; }
    }
}
