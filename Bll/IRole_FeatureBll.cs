using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Models;

namespace JBSoft.Bll
{
    public interface IRole_FeatureBll
    {	
		IResult Delete(Guid id, Guid id1, Guid userId);
		
		IResult DeleteUpdate(Guid id, Guid id1, Guid userId);

        IResult Insert(Role_Feature item, Guid userId);

        IResult Update(Role_Feature item, Guid userId);

        List<Role_Feature> SelectAll(Guid userId);

        Role_Feature SelectById(Guid id, Guid id1, Guid userId);

        List<Role_Feature> SelectByRoleId(Guid id, Guid userId);
    }
}

