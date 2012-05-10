using System;
using System.Collections.Generic;

namespace JBSoft.Dal.ResultHelpers
{
    public class InsertResult : InsertResult<Guid>, IResult
    {
        public InsertResult(List<EntityError> entityErrors)
            : base(entityErrors)
        {

        }

        public InsertResult()
            : base()
        {

        }

        public InsertResult(EntityError entityError) : base(entityError)
        {
        }
    }

    public class InsertResult<T> : IResult where T : struct
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResult"/> class when no errors exist.
        /// </summary>
        public InsertResult()
        {
            _EntityErrors = null;
        }

        public InsertResult(List<EntityError> entityErrors, T id)
        {
            _EntityErrors = entityErrors;
            _Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResult"/> class with a list of errors.
        /// </summary>
        /// <param name="entityErrors">The entity errors.</param>
        public InsertResult(List<EntityError> entityErrors)
        {
            _EntityErrors = entityErrors;
        }

        public InsertResult(EntityError entityError)
        {
            this.EntityErrors.Add(entityError);
        }

        #endregion

        #region Public Members

        public List<EntityError> EntityErrors
        {
            get 
            {
                if (_EntityErrors == null)
                    _EntityErrors = new List<EntityError>();

                return _EntityErrors; 
            }
            private set { }
        }

        public bool Success
        {
            get { return _EntityErrors == null; }
            private set { }
        }

        public T? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        #endregion

        #region Private Members

        private List<EntityError> _EntityErrors;
        private T? _Id;

        #endregion

    }
}
