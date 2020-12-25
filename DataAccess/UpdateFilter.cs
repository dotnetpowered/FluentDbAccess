using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class UpdateFilter<T> where T : class
    {
        IDatabase _database;

        public UpdateFilter(IDatabase database)
        {
            _database = database;    
        }

        public UpdateWhereGetValue<T, TProperty> Where<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);

            return new UpdateWhereGetValue<T, TProperty>(_database, propInfo);
        }

        public int Execute()
        {
            // TODO: Build object values
            var tableName = typeof(T).Name;
            return _database.Adapter.Update(tableName, null, null);
        }
    }

}