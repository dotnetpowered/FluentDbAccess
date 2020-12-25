using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class TableFindGetValue<T, TProperty> where T : class, new()
    {
        PropertyInfo _propertyInfo;
        IDatabase _database;

        public TableFindGetValue(IDatabase database, PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
            _database = database;
        }

        public TableFind<T> Is(TProperty o)
        {
            return new TableFind<T>(_database);
        }
    }
}