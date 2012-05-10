using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JBSoft.Dal.Helpers
{
    public static class EntityHelper
    {
        #region Public Members

        /// <summary>
        /// Translates all rows into a new instance of <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to return inside the collection.</typeparam>
        /// <param name="dr">An open <see cref="IDataReader"/> instance.</param>
        /// <returns>A populated instance of <see cref="IEnumerable{T}"/>.</returns>
        /// <seealso cref="TranslateSingle{T}"/>
        public static IEnumerable<T> TranslateMany<T>(this IDataReader dr) where T : new()
        {
            List<T> list = new List<T>();
            while (dr.Read())
            {
                T obj = new T();
                Type type = obj.GetType();
                var properties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
                foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase))
                {
                    if (!properties.ContainsKey(property.Name))
                        properties[property.Name] = property;
                }
                var columnName = "";
                try
                {
                    for (int i = 0; i < dr.FieldCount; ++i)
                    {
                        if (!dr.IsDBNull(i) && properties.ContainsKey(dr.GetName(i)))
                        {
                            properties[dr.GetName(i)].SetValue(obj, dr.GetValue(i), null);
                        }
                        columnName = dr.GetName(i);
                    }
                }
                catch (Exception ex)
                {
                    var value = columnName;

                }


                list.Add(obj);
            }
            return list;
        }

        public static IDictionary<string, T> TranslateMany<T>(this IDataReader dr, string keyPropertyName) where T : new()
        {
            var dictionary = new Dictionary<string, T>();

            while (dr.Read())
            {
                object key = null;

                T value = new T();
                var type = value.GetType();

                var properties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
                foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase))
                {
                    if (!properties.ContainsKey(property.Name))
                        properties[property.Name] = property;
                }

                for (int i = 0; i < dr.FieldCount; ++i)
                {
                    string fieldName = dr.GetName(i);

                    if (fieldName == keyPropertyName)
                    {
                        key = dr.GetValue(i);
                    }

                    if (!dr.IsDBNull(i) && properties.ContainsKey(dr.GetName(i)))
                    {
                        properties[dr.GetName(i)].SetValue(value, dr.GetValue(i), null);
                    }
                }
                dictionary.Add((key != null ? key.ToString() : string.Empty), value);
            }
            return dictionary;
        }

        /// <summary>
        /// Translates the next row into a new instance of T.
        /// </summary>
        /// <remarks>
        /// This method will match fields from the specified <see cref="IDataReader"/> instance
        /// to public properties on the object and return a new instance of the object with the
        /// matching fields populated.
        /// 
        /// It is important that fields and properties share the same data types as no coercion
        /// or mangling is performed.
        /// </remarks>
        /// <typeparam name="T">The type of object to return.</typeparam>
        /// <param name="dr">An open <see cref="IDataReader"/> instance.</param>
        /// <returns>A populated instance of T or <c>null</c> when there are no rows.</returns>
        public static T TranslateSingle<T>(this IDataReader dr) where T : new()
        {
            if (dr.Read())
            {
                T obj = new T();
                Type type = obj.GetType();

                var properties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
                foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase))
                {
                    if (!properties.ContainsKey(property.Name))
                        properties[property.Name] = property;
                }

                for (int i = 0; i < dr.FieldCount; ++i)
                {
                    if (!dr.IsDBNull(i) && properties.ContainsKey(dr.GetName(i)))
                    {
                        properties[dr.GetName(i)].SetValue(obj, dr.GetValue(i), null);
                    }
                }

                return obj;
            }

            return default(T);
        }

        public static IEnumerable<T> TranslateManyFields<T>(this IDataReader dr, string fieldName) where T : struct
        {
            List<T> list = new List<T>();
            int i = dr.GetOrdinal(fieldName);
            while (dr.Read())
            {
                T obj = (T)dr.GetValue(i);
                list.Add(obj);
            }
            return list;
        }

        public static T TranslateSingleField<T>(this IDataReader dr, string fieldName) where T : struct
        {
            int i = dr.GetOrdinal(fieldName);
            if (dr.Read())
            {
                T obj = (T)dr.GetValue(i);
                return obj;
            }
            return default(T);
        }

        #endregion
    }
}
