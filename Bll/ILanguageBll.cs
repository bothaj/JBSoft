using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Dal.Models;

namespace JBSoft.Bll
{
    public interface ILanguageBll
    {	
		IResult Delete(string id, Guid userId);

        IResult Insert(Language item, Guid userId);

        IResult Update(Language item, Guid userId);

        IEnumerable<Language> SelectAll(Guid userId);

        Language SelectById(string id, Guid userId);
    }
}

