using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Dal.Models;

namespace JBSoft.Bll
{
    public interface ICurrencyBll
    {	
		IResult Delete(string id, Guid userId);

        IResult Insert(Currency item, Guid userId);

        IResult Update(Currency item, Guid userId);

        IEnumerable<Currency> SelectAll(Guid userId);

        Currency SelectById(string id, Guid userId);
    }
}

