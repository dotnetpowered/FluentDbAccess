using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace DataAccess
{
    public static class ReflectionHelper
    {

        public static PropertyInfo GetPropertyInfo<T, TProperty>(Expression<Func<T, TProperty>> propertyLambda)
        {
            Type type = typeof(T);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            //Console.WriteLine("Setting: " + propInfo.Name);
            return propInfo;
        }

        public static Dictionary<string, string> ObjectToDictionary(object o)
        {
            var d = new Dictionary<string, string>();
            foreach (var prop in o.GetType().GetProperties())
            {
                d.Add(prop.Name, prop.GetValue(o).ToString());
            }
            return d;
        }

        public static IEnumerable<IDictionary<string,string>> ValuesOfObjects(IEnumerable<object> objects)
        {
            List<IDictionary<string, string>> values = new List<IDictionary<string, string>>();
            foreach (var o in objects)
            {
                values.Add(ReflectionHelper.ObjectToDictionary(o));
            }
            return values;
        }
    }
}
