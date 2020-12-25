using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class DeleteWhereGetValue<T, TProperty> where T : class
    {
        IDatabase _database;

        public DeleteWhereGetValue(IDatabase database, PropertyInfo propertyInfo)
        {
            _database = database;
        }

        public DeleteFilter<T> Is(TProperty o)
        {
            return new DeleteFilter<T>(_database);
        }
    }
}
