using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class UpdateWhereGetValue<T, TProperty> where T : class
    {
        IDatabase _database;

        public UpdateWhereGetValue(IDatabase database, PropertyInfo propertyInfo)
        {
            _database = database;
        }

        public UpdateFilter<T> Is(TProperty o)
        {
            return new UpdateFilter<T>(_database);
        }
    }
}
