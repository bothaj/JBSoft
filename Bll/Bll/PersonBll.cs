using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using JBSoft.Dal;
using JBSoft.Dal.Helpers;
using JBSoft.Dal.Models;
using JBSoft.Dal.ResultHelpers;

namespace JBSoft.Bll
{
    public class PersonBll : IPersonBll
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
                entityError.Add(new EntityError("Person", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }

        public IResult Delete(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                PersonDb.Delete(id);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Person", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }

        public IResult Insert(Person item, Guid userId)
        {
            item.StatusId = ActiveStatus.Active;
            item.CreatedUserId = userId;
            item.ModifiedUserId = userId;
            item.UtcCreatedDate = DateTime.Now;
            item.UtcModifiedDate = DateTime.Now;

            var entityError = new List<EntityError>();
            try
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();

                Guid? id = item.Id;

                PersonDb.Insert(
                ref id,
                item.FirstName,
                item.Surname,
                item.EmailAddress,
                item.PhoneHome,
                item.PhoneMobile,
                item.PhoneOffice,
                item.Fax,
                item.Description,
                item.Gender,
                item.Disability,
                item.DisabilityNote,
                item.PreferredName,
                (int)item.StatusId,
                userId);
                
                return new InsertResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Person", "Insert", ex.Message.ToString()));
                return new InsertResult(entityError);
            }
        }

        public IResult Update(Person item, Guid userId)
        {
            item.UtcModifiedDate = DateTime.Now;

            try
            {
                PersonDb.Update(
                item.Id,
                item.FirstName,
                item.Surname,
                item.EmailAddress,
                item.PhoneHome,
                item.PhoneMobile,
                item.PhoneOffice,
                item.Description,
                item.Fax,
                item.Gender,
                item.Disability,
                item.DisabilityNote,
                item.PreferredName,
                (int)item.StatusId,
                userId);

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Person", "Update", ex.InnerException.ToString()));
                return new UpdateResult(entityError);
            }
        }

        public List<Person> SelectAll(Guid userId)
        {
            using (var dr = PersonDb.SelectAll())
                return dr.TranslateMany<Person>().ToList();
        }

        public Person SelectById(Guid id, Guid userId)
        {
            using (var dr = PersonDb.SelectById(id))
                return dr.TranslateSingle<Person>();
        }

        public List<Person> SelectByUserGroupId(Guid userGroupId, Guid userId)
        {
            using (var dr = PersonDb.SelectByUserGroupId(userGroupId))
                return dr.TranslateMany<Person>().ToList();
        }

        public Person SelectByMobileNo(string mobileNo, Guid userId)
        {
            using (var dr = PersonDb.SelectByMobileNo(mobileNo))
                return dr.TranslateSingle<Person>();
        }

        public Person SelectByName(string name, Guid userId)
        {
            using (var dr = PersonDb.SelectByName(name))
                return dr.TranslateSingle<Person>();
        }

        #endregion
    }
}

