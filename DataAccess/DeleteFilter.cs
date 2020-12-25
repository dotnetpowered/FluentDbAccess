using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class DeleteFilter<T> where T : class
    {
        IDatabase _database;

        public DeleteFilter(IDatabase database)
        {
            _database = database;   
        }

        public DeleteWhereGetValue<T, TProperty> Where<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);

            return new DeleteWhereGetValue<T, TProperty>(_database, propInfo);
        }

        public int Execute()
        {
            // TODO: Build object values
            var tableName = typeof(T).Name;
            return _database.Adapter.Delete(tableName, null);
        }
    }

}