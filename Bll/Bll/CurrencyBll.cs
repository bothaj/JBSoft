using System;
using System.Collections.Generic;
using JBSoft.Dal;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Dal.Models;
using System.Data.SqlClient;
using Tangent.Logging;
using JBSoft.Dal.Helpers;

namespace JBSoft.Bll
{
    public class CurrencyBll : ICurrencyBll
    {	
		#region Public Members
		
		public IResult Delete(string id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                CurrencyDb.Delete(id);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Currency", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }

        public IResult Insert(Currency currency, Guid userId)
        {
            try
            {
                CurrencyDb.Insert
                    (
                    currency.Code,
                    currency.Name,
                    currency.Supported
                    );

                return new InsertResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Currency", "Insert", ex.Message));
                Logger.Instance.Log.ErrorException("Insert Delete", ex);
                return new InsertResult(entityError);
            }
        }

        public IEnumerable<Currency> SelectAll(Guid userId)
        {
            using (var dr = CurrencyDb.SelectAll())
                return dr.TranslateMany<Currency>();
        }

        public Currency SelectById(string id, Guid userId)
        {
            using (var dr = CurrencyDb.SelectById(id))
                return dr.TranslateSingle<Currency>();
        }

        public IResult Update(Currency currency, Guid userId)
        {
            try
            {
                CurrencyDb.Update(
                    currency.Code,
                    currency.Name,
                    currency.Supported
                    );

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Currency", "Update", ex.Message));
                Logger.Instance.Log.ErrorException("Update Delete", ex);
                return new UpdateResult(entityError);
            }
        }
		
		#endregion
    }
}

