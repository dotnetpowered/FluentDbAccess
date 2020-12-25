using System;
using System.Dynamic;
using System.Data;
using System.Collections.Generic;

namespace DataAccess
{
    public class Table<T> : IDatabase where T : class , new()
    {
        protected IDbDataAdapter _adapter;

        public Table(IDbDataAdapter adapter)
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

        public InsertIntoResult<T> Insert(T record) 
        {
            return new InsertIntoResult<T>(this, record);
        }

        public InsertIntoResult<T> Insert(IEnumerable<T> records) 
        {
            return new InsertIntoResult<T>(this, records);
        }

        // -------------------------------------------------
        //   Merge methods
        // -------------------------------------------------

        public MergeGetKey<T> MergeInto(T record)
        {
            return new MergeGetKey<T>(this, record, new List<string>());
        }

        public MergeGetKey<T> MergeInto(IEnumerable<T> records) 
        {
            return new MergeGetKey<T>(this, records, new List<string>());
        }

        // -------------------------------------------------
        //   Update methods
        // -------------------------------------------------

        public UpdateSetValue<T> Update
        {
            get
            {
                return new UpdateSetValue<T>(this);
            }
        }

        // -------------------------------------------------
        //   Delete methods
        // -------------------------------------------------

        public DeleteFilter<T> Delete
        {
            get 
            {
                return new DeleteFilter<T>(this);
            }
        }

        // -------------------------------------------------
        //   Select methods
        // -------------------------------------------------

        public TableSelectFilter<T> Select => new TableSelectFilter<T>(this);

        public TableFind<T> Find => new TableFind<T>(this);

    }
}
