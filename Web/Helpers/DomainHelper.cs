using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JBSoft.Web.Helpers
{
    public static class DomainHelper
    {
        public static IEnumerable<T> TranslateSingle<T, K>(this IEnumerable<T> view, IQueryable<K> domain)
            where K : new()
            where T : new()
        {
            K query = new K();

            List<T> list = new List<T>();

            var results = domain.Select(o => new {}).ToArray();

            foreach (var itme in results)
            {

            }



            Type type = query.GetType();

            PropertyInfo[] queryPi = type.GetProperties();

            foreach (var itm in queryPi)
            {
                PropertyInfo propertyInfo = type.GetProperty(itm.Name,
                                                             BindingFlags.Instance | BindingFlags.Public |
                                                             BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase);

                if ((propertyInfo != null))
                {
                    // propertyInfo.SetValue(obj, itm.GetValue(itm, null), null);
                }
            }

            return list;
        }
    }
}
