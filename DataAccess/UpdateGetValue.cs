using System;
using System.Reflection;

namespace DataAccess
{
    public class UpdateGetValue<T, TProperty> where T: class
    {
        IDatabase _database;

        public UpdateGetValue(IDatabase database, PropertyInfo propertyInfo)
        {
            _database = database;
        }

        public UpdateFilter<T> To(TProperty o)
        {
            return new UpdateFilter<T>(_database);
        }
    }
}
