using System;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess
{
    public class InsertIntoResult<T> where T : class
    {
        IEnumerable<T> _records;
        IDatabase _database;

        public InsertIntoResult(IDatabase database, T record)
        {
            var records = new List<T>();
            records.Add(record);
            _records = records;
            this._database = database;
        }

        public InsertIntoResult(IDatabase database, IEnumerable<T> records)
        {
            this._records = records;
            this._database = database;
        }

        public int Execute()
        {
            var tableName = typeof(T).Name;
            return _database.Adapter.Insert(tableName, ReflectionHelper.ValuesOfObjects(_records));
        }
    }
}
