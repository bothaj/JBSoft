using JBSoft.Dal.ResultHelpers;
using JBSoft.Dal.Models;
using System;
using System.Collections.Generic;
using JBSoft.Dal;
using System.Data.SqlClient;
using JBSoft.Dal.Helpers;
using Tangent.Logging;

namespace JBSoft.Bll
{
    public class UserGroupBll : IUserGroupBll
    {
        public IResult Delete(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                UserGroupDb.Delete(id);
                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("UserGroup", "Delete", ex.Message));
                Logger.Instance.Log.ErrorException("UserGroup Delete", ex);
                return new DeleteResult(entityError);
            }
        }

        public InsertResult Insert(UserGroup userGroup, Guid userId)
        {
            try
            {
                userGroup.Id = Guid.NewGuid();
                userGroup.LastUpdate = DateTime.Now;

                UserGroupDb.Insert
                    (
                    userGroup.Id,
                    userGroup.Description,
                    userGroup.Currency_Code,
                    userGroup.BackOfficeGroup
                    );

                return new InsertResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("UserGroup", "Insert", ex.Message));
                Logger.Instance.Log.ErrorException("Insert Delete", ex);
                return new InsertResult(entityError);
            }
        }

        public IEnumerable<UserGroup> SelectAll(Guid userId)
        {
            using (var dr = UserGroupDb.SelectAll())
                return dr.TranslateMany<UserGroup>();
        }

        public IEnumerable<UserGroup> SelectAllLike(string description, Guid userId)
        {
            using (var dr = UserGroupDb.SelectAllLike(description, userId))
                return dr.TranslateMany<UserGroup>();
        }

        public UserGroup SelectOneLike(string description, Guid userId)
        {
            using (var dr = UserGroupDb.SelectAllLike(description, userId))
                return dr.TranslateSingle<UserGroup>();
        }

        public UserGroup SelectById(Guid id, Guid userId)
        {
            using (var dr = UserGroupDb.SelectById(id))
                return dr.TranslateSingle<UserGroup>();
        }

        public UpdateResult Update(UserGroup userGroup, Guid userId)
        {
            var entityToUpdate = this.SelectById(userGroup.Id, userId);
            entityToUpdate.Description = userGroup.Description;
            entityToUpdate.Currency_Code = userGroup.Currency_Code;
            entityToUpdate.LastUpdate = DateTime.Now;
            entityToUpdate.BackOfficeGroup = userGroup.BackOfficeGroup;

            try
            {
                UserGroupDb.Update(
                    entityToUpdate.Id,
                    entityToUpdate.Description,
                    entityToUpdate.Currency_Code,
                    entityToUpdate.BackOfficeGroup
                    );

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("UserGroup", "Update", ex.Message));
                Logger.Instance.Log.ErrorException("Update Delete", ex);
                return new UpdateResult(entityError);
            }
        }

        public InsertResult AddModule(Guid userGroupId, Guid moduleId, Guid userId)
        {
            try
            {
                UserGroupDb.InsertModule
                    (
                    userGroupId,
                    moduleId,
                    userId,
                    1,
                    userId,
                    DateTime.Now
                    );

                return new InsertResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("UserGroup", "AddModule", ex.Message));
                Logger.Instance.Log.ErrorException("Insert AddModule", ex);
                return new InsertResult(entityError);
            }
        }

        public InsertResult RemoveModule(Guid userGroupId, Guid moduleId, Guid userId)
        {
            try
            {
                UserGroupDb.DeleteModule
                    (
                    userGroupId,
                    moduleId,
                    userId
                    );

                return new InsertResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("UserGroup", "RemoveModule", ex.Message));
                Logger.Instance.Log.ErrorException("Insert RemoveModule", ex);
                return new InsertResult(entityError);
            }
        }
    }
}
