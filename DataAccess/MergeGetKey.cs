using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;
            
namespace DataAccess
{
    public class MergeGetKey<T> where T : class, new()
    {
        IEnumerable<T> _records;
        IDatabase _database;
        List<string> _keys;

        public MergeGetKey(IDatabase database, IEnumerable<T> records, List<string> keys)
        {
            _records = records;
            _database = database;
            _keys = keys;
        }

        public MergeGetKey(IDatabase database, T record, List<string> keys)
        {
            var records = new List<T>();
            records.Add(record);
            _records = records;
            _database = database;
            _keys = keys;
        }

        public MergeGetKey<T> On<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);
            _keys.Add(propInfo.Name);
            return new MergeGetKey<T>(_database, _records, _keys);
        }

        public int Execute()
        {
            var tableName = typeof(T).Name;
            return _database.Adapter.Merge(tableName, ReflectionHelper.ValuesOfObjects(_records), _keys);
        }
    }
}
