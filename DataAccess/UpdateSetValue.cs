using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class UpdateSetValue<T> where T : class, new()
    {
        IDatabase _database;

        public UpdateSetValue(IDatabase database)
        {
            _database = database;
        }

        public UpdateGetValue<T, TProperty> Set<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);

            return new UpdateGetValue<T, TProperty>(_database, propInfo);
        }


    }
}
