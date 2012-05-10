using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Models;

namespace JBSoft.Bll
{
    public interface IFeatureBll
    {	
		IResult Delete(Guid id, Guid userId);
		
		IResult DeleteUpdate(Guid id, Guid userId);

        IResult Insert(Feature item, Guid userId);

        IResult Update(Feature item, Guid userId);

        List<Feature> SelectAll(Guid userId);

        Feature SelectById(Guid id, Guid userId);
    }
}

