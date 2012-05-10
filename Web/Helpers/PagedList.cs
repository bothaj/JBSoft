using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBSoft.Web.Helpers
{
    /// <summary>
    /// Paged List
    /// </summary>
    public class PagedList<T> : List<T>
    {
        public int CurrentPageIndex { get; private set; }
        public bool PreviousPageExists { get; private set; }
        public bool NextPageExists { get; private set; }

        public PagedList(IQueryable<T> source, int index, int itemsPerPage)
        {
            Initialize(source, index, itemsPerPage);
        }

        public PagedList(IQueryable<T> source, Func<T, bool> constraint, int itemsPerPage)
        {
            var itemsBeforeMatch = source.ToList().TakeWhile(x => constraint(x) == false);
            var itemsIncludingMatch = source.Take(itemsBeforeMatch.Count() + 1).ToList();

            var index = 0;
            if (!itemsIncludingMatch.TrueForAll(x => constraint(x) == false))
            {
                index = (int)Math.Ceiling(((decimal)itemsIncludingMatch.Count) / itemsPerPage) - 1;
            }

            Initialize(source, index, itemsPerPage);
        }

        /// <summary>
        /// Initializes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        private void Initialize(IQueryable<T> source, int index, int itemsPerPage)
        {
            // Take one more item than specified - to determine if a 'next' page exists
            var pageSpecified = source.Skip(index * itemsPerPage).Take(itemsPerPage + 1).ToList();

            AddRange(pageSpecified.Take(itemsPerPage));

            CurrentPageIndex = index;
            PreviousPageExists = index != 0;
            NextPageExists = pageSpecified.Count == itemsPerPage + 1;
        }
    }
}
