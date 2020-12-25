using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class SelectWhereGetValue<T, TProperty> where T : class, new()
    {
        PropertyInfo _propertyInfo;
        IDatabase _database;

        public SelectWhereGetValue(IDatabase database, PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
            _database = database;
        }

        public TableSelectFilter<T> Is(TProperty o)
        {
            return new TableSelectFilter<T>(_database);
        }

        public TableSelectFilter<T> GreaterThan(TProperty o)
        {
            return new TableSelectFilter<T>(_database);
        }

        public T Execute()
        {
            // TODO: get values from where clause
            var tableName = typeof(T).Name;
            var reader = _database.Adapter.Select(tableName, null);
            return new T();
        }
    }
}