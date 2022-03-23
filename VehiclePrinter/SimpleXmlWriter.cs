using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Xml.Linq;

namespace VehiclePrinter
{
    public class SimpleXmlWriter<T>
    {
        public T Item { get; }

        public SimpleXmlWriter([DisallowNull] T item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }
        public void Save(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Create);
            Save(fs);
        }

        public void Save(Stream fileStream)
        {
            var doc = new XDocument( new XElement(typeof(T).Name, CreateChildNodes(Item)));
            doc.Save(fileStream);
        }

        private IEnumerable<XElement> CreateChildNodes(object obj)
        {
            if (obj is IEnumerable list) return CreateNodesForEnumerable(list);
            return CreateChildNodesForObject(obj);
        }

        private IEnumerable<XElement> CreateChildNodesForObject(object obj)
        {
;           var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value is not null)
                    yield return CreateChildNode(value, property);
            }
        }

        private IEnumerable<XElement> CreateNodesForEnumerable(IEnumerable list)
        {
            return from object? obj in list select new XElement(obj.GetType().Name, GetPropertyXValue(obj));
        }

        private XElement CreateChildNode(object value, MemberInfo property)
        {
            return new XElement(property.Name, GetPropertyXValue(value));
        }

        private object GetPropertyXValue(object value)
        {
            return IsSimple(value.GetType()) ? value : CreateChildNodes(value);
        }

        private static bool IsSimple(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsSimple(type.GetGenericArguments()[0]);
            }
            return type.IsPrimitive
                   || type.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal);
        }
    }
}
