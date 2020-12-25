using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccess.Mocks
{
    public class MockDbAdapter : IDbDataAdapter
    {
        public MockDbAdapter()
        {
        }

        public int Insert(string tableName, IEnumerable<IDictionary<string, string>> values)
        {
            DebugDisplay("Insert", tableName, values);
            return values.Count();
        }

        public int Merge(string tableName, IEnumerable<IDictionary<string, string>> values, IEnumerable<string> keys)
        {
            DebugDisplay("Merge", tableName, values);
            Console.Write("  With key(s): ");
            foreach (var key in keys) {
                Console.Write(key+" ");
            }
            Console.WriteLine();
            return values.Count();
        }

        public int Delete(string tableName, IDictionary<string, ValueCompare> where)
        {
            Console.WriteLine("Delete from " + tableName);
            return 0;
        }

        public IDataReader Execute(string procName, string[] values)
        {
            Console.WriteLine("Execute {0}", procName);
            return null;
        }

        public IDataReader Select(string tableName, IDictionary<string, ValueCompare> where)
        {
            Console.WriteLine("Select from {0}", tableName);
            return null;
        }

        public int Update(string tableName, IDictionary<string, string> values, IDictionary<string, ValueCompare> where)
        {
            Console.WriteLine("Update {0}", tableName);
            return 0;
        }

        private void DebugDisplay(string operation, string tableName, IEnumerable<IDictionary<string, string>> values)
        {
            Console.WriteLine("{0} into {1} {2} record(s)", operation, tableName, values.Count());
            foreach (var record in values)
            {
                Console.Write("  Record [ ");
                foreach (var field in record)
                {
                    Console.Write("{0}: {1}; ", field.Key, field.Value);
                }
                Console.WriteLine("]");
            }
        }
    }
}
