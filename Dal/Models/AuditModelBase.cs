using System;
using JBSoft.Dal.Models;

namespace JBSoft.Models
{
    /// <summary>
    /// Provides the common base fields that all the models implement
    /// to assist with auditing of the data
    /// </summary>
    [Serializable]
    public abstract class AuditModelBase
    {
        public ActiveStatus StatusId { get; set; }

        public Guid CreatedUserId { get; set; }

        public DateTime UtcCreatedDate { get; set; }

        public DateTime UtcModifiedDate { get; set; }

        public Guid ModifiedUserId { get; set; }

        public int RowCount { get; set; }

        #region Constructor

        protected AuditModelBase()
        {
            this.StatusId = ActiveStatus.Active;
        }

        #endregion
    }
}

