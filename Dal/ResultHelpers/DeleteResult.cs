using System;
using System.Collections.Generic;

namespace JBSoft.Dal.ResultHelpers
{
    public class DeleteResult : DeleteResult<Guid>, IResult
    {
        public DeleteResult(List<EntityError> entityErrors)
            : base(entityErrors)
        {
        }

        public DeleteResult()
            : base()
        {
        }

        public DeleteResult(EntityError entityError)
            : base()
        {
        }
    }

    public class DeleteResult<T> : IResult where T : struct
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResult"/> class when no errors exist.
        /// </summary>
        public DeleteResult()
        {
            _EntityErrors = null;
        }

        public DeleteResult(List<EntityError> entityErrors, T id)
        {
            _EntityErrors = null;
            _Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateResult"/> class with a list of errors.
        /// </summary>
        /// <param name="entityErrors">The entity errors.</param>
        public DeleteResult(List<EntityError> entityErrors)
        {
            _EntityErrors = entityErrors;
        }

        public DeleteResult(EntityError entityError)
        {

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
            private set { }
        }

        #endregion

        #region Private Members

        private List<EntityError> _EntityErrors;
        private readonly T? _Id;

        #endregion

    }
}
