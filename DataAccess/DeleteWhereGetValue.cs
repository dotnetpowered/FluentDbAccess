using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public class DeleteWhereGetValue<T, TProperty> where T : class
    {
        DeleteFilter<T> _deleteFilter;
        PropertyInfo _propertyInfo;

        public DeleteWhereGetValue(DeleteFilter<T> deleteFilter, PropertyInfo propertyInfo)
        {
            _deleteFilter = deleteFilter;
            _propertyInfo = propertyInfo;
        }

        public DeleteFilter<T> Is(TProperty o)
        {
            _deleteFilter.WhereValues.Add(_propertyInfo.Name, new ValueCompare() { Value = o.ToString() });
            return _deleteFilter;
        }
    }
}
