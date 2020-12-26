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

        private Dictionary<string, ValueCompare> _where = new();
        internal Dictionary<string, ValueCompare> WhereValues { get => _where; set => _where = value; }

        public DeleteFilter(IDatabase database)
        {
            _database = database;   
        }

        public DeleteWhereGetValue<T, TProperty> Where<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);

            return new DeleteWhereGetValue<T, TProperty>(this, propInfo);
        }

        public int Execute()
        {
            var tableName = typeof(T).Name;
            return _database.Adapter.Delete(tableName, _where);
        }
    }

}