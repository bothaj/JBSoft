using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBSoft.Dal.Models
{
    public class DescriptionIdPair<T> where T : struct
    {
        #region Public Members

        /// <remarks>
        /// The Description of the Entity in the Pair.
        /// </remarks>
        public string Description { get; set; }

        /// <remarks>
        /// The Id of the Entity in the Pair.
        /// </remarks>
        public T Id { get; set; }

        public static IEqualityComparer<DescriptionIdPair<T>> IdComparer
        {
            get { return _IdComparer; }
        }

        #endregion

        #region Private Members

        private sealed class CompareIdOnly : IEqualityComparer<DescriptionIdPair<T>>
        {
            #region IEqualityComparer<DescriptionIdPair<T>> Members

            public bool Equals(DescriptionIdPair<T> x, DescriptionIdPair<T> y)
            {
                return (x != null) && (y != null) && (x.Id.Equals(y.Id));
            }

            public int GetHashCode(DescriptionIdPair<T> obj)
            {
                if (obj == null)
                    throw new ArgumentNullException("obj");

                return obj.GetHashCode();
            }

            #endregion
        }

        private static readonly IEqualityComparer<DescriptionIdPair<T>> _IdComparer = new CompareIdOnly();

        #endregion
    }
}
