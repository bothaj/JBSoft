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
    public class FeatureBll : IFeatureBll
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
                entityError.Add(new EntityError("Feature", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Delete(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                FeatureDb.Delete(id);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Feature", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Insert(Feature item, Guid userId)
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
				
                FeatureDb.Insert(
				id,
				item.Module_Id,
				item.Description_Id,
				item.FeatureSection_Id);

                return new InsertResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Feature", "Insert", ex.Message.ToString()));
                return new InsertResult(entityError);
            }
        }
		
		public IResult Update(Feature item, Guid userId)
        {
            try
            {
				FeatureDb.Update(
				item.Id,
				item.Module_Id,
				item.Description_Id,
				item.FeatureSection_Id);

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Feature", "Update", ex.InnerException.ToString()));
                return new UpdateResult(entityError);
            }
        }
		
		public List<Feature> SelectAll(Guid userId)
        {
            using (var dr = FeatureDb.SelectAll())
                return dr.TranslateMany<Feature>().ToList();
        }

        public Feature SelectById(Guid id, Guid userId)
        {
            using (var dr = FeatureDb.SelectById(id))
                return dr.TranslateSingle<Feature>();
        }
		
		#endregion
    }
}

