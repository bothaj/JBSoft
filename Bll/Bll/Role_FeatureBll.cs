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
    public class Role_FeatureBll : IRole_FeatureBll
    {	
		#region Public Members
		
		public IResult DeleteUpdate(Guid roleId, Guid featureId, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                var entityToDelete = this.SelectById(roleId, featureId, userId);
                entityToDelete.StatusId = ActiveStatus.Deleted;

                return this.Update(entityToDelete, userId);
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Role_Feature", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Delete(Guid roleId, Guid featureId, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                Role_FeatureDb.Delete(roleId, featureId);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Role_Feature", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Insert(Role_Feature item, Guid userId)
        {
            item.StatusId = ActiveStatus.Active;
            item.CreatedUserId = userId;
            item.ModifiedUserId = userId;

            var entityError = new List<EntityError>();
            try
            {
				
                Role_FeatureDb.Insert(
				item.Role_Id,
				item.Feature_Id,
				(int?)item.StatusId,
				item.CreatedUserId,
				item.UtcCreatedDate,
				item.ModifiedUserId,
				item.UtcModifiedDate);

                return new InsertResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Role_Feature", "Insert", ex.Message.ToString()));
                return new InsertResult(entityError);
            }
        }
		
		public IResult Update(Role_Feature item, Guid userId)
        {
            try
            {
				Role_FeatureDb.Update(
				item.Role_Id,
				item.Feature_Id,
				(int?)item.StatusId,
				item.CreatedUserId,
				item.UtcCreatedDate,
				item.ModifiedUserId,
				item.UtcModifiedDate);

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Role_Feature", "Update", ex.InnerException.ToString()));
                return new UpdateResult(entityError);
            }
        }
		
		public List<Role_Feature> SelectAll(Guid userId)
        {
            using (var dr = Role_FeatureDb.SelectAll())
                return dr.TranslateMany<Role_Feature>().ToList();
        }

        public Role_Feature SelectById(Guid roleId, Guid featureId, Guid userId)
        {
            using (var dr = Role_FeatureDb.SelectById(roleId, featureId))
                return dr.TranslateSingle<Role_Feature>();
        }

        public List<Role_Feature> SelectByRoleId(Guid roleId, Guid userId)
        {
            using (var dr = Role_FeatureDb.SelectByRoleId(roleId))
                return dr.TranslateMany<Role_Feature>().ToList();
        }

		#endregion
    }
}

