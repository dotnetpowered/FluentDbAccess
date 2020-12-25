using System;
using System.Dynamic;
using System.Data;
using System.Collections.Generic;

namespace DataAccess
{
    public abstract class DatabaseBase : IDatabase
    {
        protected IDbDataAdapter _adapter;

        public DatabaseBase(IDbDataAdapter adapter)
        {
            _adapter = adapter;
        }

        public IDbDataAdapter Adapter
        {
            get { return _adapter; }
        }

       
        // -------------------------------------------------
        //   Stored Procedure methods
        // -------------------------------------------------

        protected IEnumerable<T> Execute<T>(string ProcName, params object[] p) where T : class, new()
        {
            // TODO: handle parameters clause
            // TODO: handle returned data reader
            var reader = _adapter.Execute(ProcName, null);
            return new List<T>();
        }

        protected void Execute(string ProcName, params object[] p)
        {
            // TODO: handle parameters
            _adapter.Execute(ProcName, null);
        }
    }
}
