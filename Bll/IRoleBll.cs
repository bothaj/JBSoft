using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Models;

namespace JBSoft.Bll
{
    public interface IRoleBll
    {	
		IResult Delete(Guid id, Guid userId);
		
		IResult DeleteUpdate(Guid id, Guid userId);

        IResult Insert(Role item, Guid userId);

        IResult Update(Role item, Guid userId);

        List<Role> SelectAll(Guid userId);

        Role SelectById(Guid id, Guid userId);
    }
}

