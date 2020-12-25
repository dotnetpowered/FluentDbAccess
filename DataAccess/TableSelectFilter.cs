using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class TableSelectFilter<T> where T : class, new()
    {
        IDatabase _database;

        public TableSelectFilter(IDatabase database)
        {
            _database = database;
        }

        public SelectWhereGetValue<T, TProperty> Where<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);

            return new SelectWhereGetValue<T, TProperty>(_database, propInfo);
        }

        public List<T> AsList()
        {
            // TODO get where clause
            // TODO process reader
            var tableName = typeof(T).Name;
            var reader = _database.Adapter.Select(tableName, null);
            return new List<T>();
        }

        public T[] AsArray()
        {
            // TODO get where clause
            // TODO process reader
            var tableName = typeof(T).Name;
            var reader = _database.Adapter.Select(tableName, null);
            return new List<T>().ToArray();
        }
    }
}