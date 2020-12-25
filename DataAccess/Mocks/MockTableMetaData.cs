using System;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess.Mocks
{
    public class MockTableMetaData<T> where T : class
    {
        public MockTableMetaData()
        {
        }

        public MockTableMetaData<T> RegisterIdentityColumn<TProperty>(
                Expression<Func<T, TProperty>> propertyLambda)
        {
            PropertyInfo propInfo = ReflectionHelper.GetPropertyInfo<T, TProperty>(propertyLambda);
            this.IdentityColumn = propInfo.Name;
            return this;
        }

        public MockTableMetaData<T> SetSchema(string schema)
        {
            this.Schema = schema;
            return this;
        }

        public string Schema { get; private set; }
        public string IdentityColumn { get; private set; }
    }
}
