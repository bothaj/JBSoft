using System;

namespace JBSoft.Dal.ResultHelpers
{
    public sealed class EntityError
    {
        #region Constructors

        public EntityError(string entityName, string propertyName, string errorMessage)
        {
            _EntityName = entityName;
            _ErrorMessage = errorMessage;
            _PropertyName = propertyName;
        }

        #endregion

        #region Public Members

        public string EntityName
        {
            get { return _EntityName; }
            private set { }
        }

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            private set { }
        }

        public string PropertyName
        {
            get { return _PropertyName; }
            private set { }
        }

        #endregion

        #region Private Members

        private readonly string _EntityName;
        private readonly string _ErrorMessage;
        private readonly string _PropertyName;

        #endregion

        #region Public Static Members

        public static string EntityErrorsToString(EntityError[] EntityErrors)
        {
            string entityErrors = string.Empty;

            foreach (var error in EntityErrors)
            {
                entityErrors += error.ErrorMessage + "; ";
            }

            if (!String.IsNullOrEmpty(entityErrors))
            {
                entityErrors = entityErrors.Remove(entityErrors.Length - 2);
            }

            return entityErrors;
        }

        #endregion
    }
}
