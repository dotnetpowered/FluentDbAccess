using System;
using System.Dynamic;
using System.Data;
using System.Collections.Generic;

namespace DataAccess
{
    public class Database : IDatabase
    {
        protected IDbDataAdapter _adapter;

        public Database(IDbDataAdapter adapter)
        {
            _adapter = adapter;
        }

        public IDbDataAdapter Adapter
        {
            get { return _adapter; }
        }

        // -------------------------------------------------
        //   Insert methods
        // -------------------------------------------------

        public InsertIntoResult<T> InsertInto<T>(T record) where T : class
        {
            return new InsertIntoResult<T>(this, record);
        }

        public InsertIntoResult<T> InsertInto<T>(IEnumerable<T> records) where T : class
        {
            return new InsertIntoResult<T>(this, records);
        }

        // -------------------------------------------------
        //   Merge methods
        // -------------------------------------------------

        public MergeGetKey<T> MergeInto<T>(T record) where T : class, new()
        {
            return new MergeGetKey<T>(this, record, new List<string>());
        }

        public MergeGetKey<T> MergeInto<T>(IEnumerable<T> records) where T : class, new()
        {
            return new MergeGetKey<T>(this, records, new List<string>());
        }

        // -------------------------------------------------
        //   Update methods
        // -------------------------------------------------

        public UpdateSetValue<T> Update<T>() where T : class, new()
        {
            return new UpdateSetValue<T>(this);
        }

        // -------------------------------------------------
        //   Delete methods
        // -------------------------------------------------

        public DeleteFilter<T> DeleteFrom<T>() where T : class
        {
            return new DeleteFilter<T>(this);
        }

        // -------------------------------------------------
        //   Select methods
        // -------------------------------------------------

        public TableSelectFilter<T> SelectFrom<T>() where T : class, new()
        {
            return new TableSelectFilter<T>(this);
        }

        public TableFind<T> Find<T>() where T : class, new()
        {
            return new TableFind<T>(this);
        }

    }
}
