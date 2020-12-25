using System;
using System.Data;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IDbDataAdapter
    {
        int Insert(string tableName, IEnumerable<IDictionary<string, string>> values);
        int Merge(string tableName, IEnumerable<IDictionary<string, string>> values, IEnumerable<string> keys);
        int Update(string tableName, IDictionary<string, string> values, IDictionary<string, ValueCompare> where);
        int Delete(string tableName, IDictionary<string, ValueCompare> where);
        IDataReader Execute(string procName, string[] values);
        IDataReader Select(string tableName, IDictionary<string, ValueCompare> where);
    }

    public class ValueCompare
    {
        public string Value { get; set; }
    }
}
