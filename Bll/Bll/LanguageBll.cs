using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.Models;
using JBSoft.Dal.ResultHelpers;
using System.Data.SqlClient;
using Tangent.Logging;
using JBSoft.Dal.Helpers;

namespace JBSoft.Bll
{
    public class LanguageBll : ILanguageBll
    {	
		#region Public Members
		
		public IResult Delete(string id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                LanguageDb.Delete(id);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Language", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }

        public IResult Insert(Language language, Guid userId)
        {
            try
            {
                LanguageDb.Insert
                    (
                    language.Code,
                    language.Description_Id,
                    language.Supported
                    );

                return new InsertResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Language", "Insert", ex.Message));
                Logger.Instance.Log.ErrorException("Insert Delete", ex);
                return new InsertResult(entityError);
            }
        }

        public IEnumerable<Language> SelectAll(Guid userId)
        {
            using (var dr = LanguageDb.SelectAll())
                return dr.TranslateMany<Language>();
        }

        public Language SelectById(string id, Guid userId)
        {
            using (var dr = LanguageDb.SelectById(id))
                return dr.TranslateSingle<Language>();
        }

        public IResult Update(Language language, Guid userId)
        {
            try
            {
                LanguageDb.Update(
                    language.Code,
                    language.Description_Id,
                    language.Supported
                    );

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Language", "Update", ex.Message));
                Logger.Instance.Log.ErrorException("Update Delete", ex);
                return new UpdateResult(entityError);
            }
        }
		
		#endregion
    }
}

