using System;
using System.Collections.Generic;

namespace JBSoft.Dal.ResultHelpers
{
    public class UpdateResult : UpdateResult<Guid>, IResult
    {
        public UpdateResult(List<EntityError> entityErrors)
            : base(entityErrors)
        {

        }

        public UpdateResult()
            : base()
        {

        }

        public UpdateResult(EntityError entityError)
            : base(entityError)
        {
        }
    }

    public class UpdateResult<T> : IResult where T : struct
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResult"/> class when no errors exist.
        /// </summary>
        public UpdateResult()
        {
            _EntityErrors = null;
        }

        public UpdateResult(List<EntityError> entityErrors, T id)
        {
            _EntityErrors = null;
            _Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResult"/> class with a list of errors.
        /// </summary>
        /// <param name="entityErrors">The entity errors.</param>
        public UpdateResult(List<EntityError> entityErrors)
        {
            _EntityErrors = entityErrors;
        }

        public UpdateResult(EntityError entityError)
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
            set 
            {
                _EntityErrors = value;
            }
        }

        public int RowsAffected
        {
            get { return 0; }
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
            private set { }
        }

        #endregion

        #region Private Members

        private List<EntityError> _EntityErrors;
        private T? _Id;

        #endregion

    }
}
