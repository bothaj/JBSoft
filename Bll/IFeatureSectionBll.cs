using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Models;

namespace JBSoft.Bll
{
    public interface IFeatureSectionBll
    {	
		IResult Delete(Guid id, Guid userId);
		
		IResult DeleteUpdate(Guid id, Guid userId);

        IResult Insert(FeatureSection item, Guid userId);

        IResult Update(FeatureSection item, Guid userId);

        List<FeatureSection> SelectAll(Guid userId);

        FeatureSection SelectById(Guid id, Guid userId);
    }
}

