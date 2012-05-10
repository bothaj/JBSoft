using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.Dal;
using JBSoft.Dal.Helpers;
using JBSoft.Dal.Models;
using JBSoft.Dal.ResultHelpers;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Configuration;

namespace JBSoft.Bll
{
    public class UserBll : IUserBll
    {
        public IResult Delete(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                UserDb.Delete(id);
                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("User", "Delete", ex.Message));
                return new DeleteResult(entityError);
            }
        }

        public IEnumerable<User> SelectAll(Guid userId)
        {
            using (var dr = UserDb.SelectAll())
                return dr.TranslateMany<User>();
        }

        public IEnumerable<User> SelectAdminUsers(Guid adminGroupId, Guid userId)
        {
            using (var dr = UserDb.SelectAdminUsers(adminGroupId))
                return dr.TranslateMany<User>();
        }

        public User SelectById(Guid id, Guid userId)
        {
            using (var dr = UserDb.SelectById(id))
                return dr.TranslateSingle<User>();
        }

        public User SelectLikeId(string likeUserId, Guid userId)
        {
            using (var dr = UserDb.SelectLikeId(likeUserId))
                return dr.TranslateSingle<User>();
        }

        public IEnumerable<User> SelectByUserGroupId(Guid serGroupId, Guid userId)
        {
            using (var dr = UserDb.SelectByUserGroupId(serGroupId))
                return dr.TranslateMany<User>();
        }

        public IEnumerable<User> SelectBySubEventId(Guid? subEventId, Guid userId)
        {
            using (var dr = UserDb.SelectBySubEventId(subEventId))
                return dr.TranslateMany<User>();
        }

        public IEnumerable<User> SelectByGroupingId(Guid? groupingId, Guid userId)
        {
            using (var dr = UserDb.SelectByGroupingId(groupingId))
                return dr.TranslateMany<User>();
        }

        public IEnumerable<User> SelectByAttendeeGuestTypeId(int? attendeeTypeId, int? guestTypeId, Guid userId)
        {
            using (var dr = UserDb.SelectByAttendeeGuestTypeId(attendeeTypeId, guestTypeId))
                return dr.TranslateMany<User>();
        }

        public IEnumerable<User> Search(string name, string email, string username, Guid userId)
        {
            using (var dr = UserDb.Search(name, email, username))
                return dr.TranslateMany<User>();
        }

        public User SelectUserByUserName(string userName)
        {
            using (var dr = UserDb.SelectByUsername(userName))
                return dr.TranslateSingle<User>();
        }

        public IResult Insert(User user, Guid userId)
        { 
            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Guid? id;

                        if (user.Id == null)
                        {
                            id = Guid.NewGuid();
                        }
                        else
                        {
                            // jhj - id = user.Id;
                            id = userId;
                        }

                        user.UtcCreatedDate = DateTime.Now;

                        UserDb.Insert(transaction,
                                      id,
                                      user.Username,
                                      user.PasswordHash,
                                      user.PasswordHint,
                                      user.Language_Code,
                                      user.Description,
                                      user.UserGroup_Id,
                                      (int)user.StatusId,
                                      user.CreatedUserId,
                                      user.UtcCreatedDate);

                        PersonDb.Insert(transaction,
                            ref id,
                            user.FirstName,
                            user.Surname,
                            user.EmailAddress,
                            user.PhoneHome,
                            user.PhoneMobile,
                            user.PhoneOffice,
                            user.Fax,
                            user.Description,
                            user.Gender,
                            user.Disability,
                            user.DisabilityNote,
                            user.PreferredName,
                            (int) ActiveStatus.Active,
                            userId);

                        transaction.Commit();
                        return new InsertResult();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        var entityError = new EntityError("UserBll", "Insert", ex.Message);
                        return new InsertResult(entityError);
                    }
                }
            }
        }

        public IResult Update(User entityToUpdate, Guid userId)
        {
            //entityToUpdate.LastUpdate = DateTime.Now;

            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        if (entityToUpdate.PasswordHash == null)
                        {
                            var oldEntity = this.SelectById(entityToUpdate.Id, userId);
                            entityToUpdate.PasswordHash = oldEntity.PasswordHash;
                            entityToUpdate.PasswordHint = oldEntity.PasswordHint;
                        }

                        UserDb.Update(transaction,
                            entityToUpdate.Id,
                            entityToUpdate.Username,
                            entityToUpdate.PasswordHash,
                            entityToUpdate.PasswordHint,
                            entityToUpdate.Language_Code,
                            entityToUpdate.Description,
                            entityToUpdate.UserGroup_Id,
                            null
                            );

                        PersonDb.Update(transaction,
                            entityToUpdate.Id,
                            entityToUpdate.FirstName,
                            entityToUpdate.Surname,
                            entityToUpdate.EmailAddress,
                            entityToUpdate.PhoneHome,
                            entityToUpdate.PhoneMobile,
                            entityToUpdate.PhoneOffice,
                            entityToUpdate.Fax,
                            entityToUpdate.Description,
                            entityToUpdate.Gender,
                            entityToUpdate.Disability,
                            entityToUpdate.DisabilityNote,
                            entityToUpdate.PreferredName,
                            (int)entityToUpdate.StatusId,
                            userId);

                        transaction.Commit();
                        return new UpdateResult();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();

                        var entityError = new List<EntityError>();
                        entityError.Add(new EntityError("User", "Update", ex.Message));
                        return new UpdateResult(entityError);
                    }
                }
            }
        }
    }
}
