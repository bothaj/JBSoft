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
    public class RoleBll : IRoleBll
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
                entityError.Add(new EntityError("Role", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Delete(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                RoleDb.Delete(id);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Role", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }
		
		public IResult Insert(Role item, Guid userId)
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
				
                RoleDb.Insert(
				id,
				item.Description,
				item.IsSystemRole);

                return new InsertResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Role", "Insert", ex.Message.ToString()));
                return new InsertResult(entityError);
            }
        }
		
		public IResult Update(Role item, Guid userId)
        {
            try
            {
				RoleDb.Update(
				item.Id,
				item.Description,
				item.IsSystemRole);

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Role", "Update", ex.InnerException.ToString()));
                return new UpdateResult(entityError);
            }
        }
		
		public List<Role> SelectAll(Guid userId)
        {
            using (var dr = RoleDb.SelectAll())
                return dr.TranslateMany<Role>().ToList();
        }

        public Role SelectById(Guid id, Guid userId)
        {
            using (var dr = RoleDb.SelectById(id))
                return dr.TranslateSingle<Role>();
        }
		
		#endregion
    }
}

