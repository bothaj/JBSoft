using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using JBSoft.Dal;
using JBSoft.Dal.Helpers;
using JBSoft.Models;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Dal.Models;

namespace JBSoft.Bll
{
    public class FeatureSectionBll : IFeatureSectionBll
    {	
		#region Public Members
		
		public IResult DeleteUpdate(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                var entityToDelete = this.SelectById(id, userId);
                entityToDelete.StatusId = ActiveStatus.Deleted;

                return this.Update(entityToDelete, userId);
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("FeatureSection", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Delete(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                FeatureSectionDb.Delete(id);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("FeatureSection", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Insert(FeatureSection item, Guid userId)
        {
            item.StatusId = ActiveStatus.Active;
            item.CreatedUserId = userId;
            item.ModifiedUserId = userId;

            var entityError = new List<EntityError>();
            try
            {
				if (item.Id == Guid.Empty)
					item.Id = Guid.NewGuid();
				
				Guid? id = item.Id;
				
                FeatureSectionDb.Insert(
				id,
				item.Description_Id,
				item.ImageUrl,
				item.SortOrder,
				(int?)item.StatusId);

                return new InsertResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("FeatureSection", "Insert", ex.Message.ToString()));
                return new InsertResult(entityError);
            }
        }
		
		public IResult Update(FeatureSection item, Guid userId)
        {
            try
            {
				FeatureSectionDb.Update(
				item.Id,
				item.Description_Id,
				item.ImageUrl,
				item.SortOrder,
				(int?)item.StatusId);

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("FeatureSection", "Update", ex.InnerException.ToString()));
                return new UpdateResult(entityError);
            }
        }
		
		public List<FeatureSection> SelectAll(Guid userId)
        {
            using (var dr = FeatureSectionDb.SelectAll())
                return dr.TranslateMany<FeatureSection>().ToList();
        }

        public FeatureSection SelectById(Guid id, Guid userId)
        {
            using (var dr = FeatureSectionDb.SelectById(id))
                return dr.TranslateSingle<FeatureSection>();
        }
		
		#endregion
    }
}

