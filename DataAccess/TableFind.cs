using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class TableFind<T> where T : class, new()
    {
        IDatabase _database;

        public TableFind(IDatabase database)
        {
            _database = database;   
        }

        public TableFindGetValue<T, TProperty> Where<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);

            return new TableFindGetValue<T, TProperty>(_database, propInfo);
        }

        public T Value()
        {
            // TODO: get where values
            // TODO: process reader
            var tableName = typeof(T).Name;
            var reader = _database.Adapter.Select(tableName, null);
            return new T();
        }
    }
}

