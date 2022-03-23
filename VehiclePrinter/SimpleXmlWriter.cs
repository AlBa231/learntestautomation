using System.Collections;
using System.Reflection;
using System.Xml.Linq;

namespace VehiclePrinter
{
    public class SimpleXmlWriter
    {
        public object Item { get; }

        public SimpleXmlWriter(object item)
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
            var doc = new XDocument(CreateXElement(Item));
            doc.Save(fileStream);
        }

        private XElement CreateXElement(object obj)
        {
            return new XElement(obj.GetType().Name, GetPropertyXValue(obj));
        }

        private object GetPropertyXValue(object value)
        {
            return value.GetType().IsSimple() ? value : CreateChildNodes(value);
        }

        private IEnumerable<XElement> CreateChildNodes(object obj)
        {
            if (obj is IEnumerable list) return list.Cast<object>().Select(CreateXElement);
            return CreateChildNodesForObject(obj);
        }

        private IEnumerable<XElement> CreateChildNodesForObject(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj);
                if (value is not null)
                    yield return CreateChildNode(value, property);
            }
        }

        private XElement CreateChildNode(object value, MemberInfo property)
        {
            return new XElement(property.Name, GetPropertyXValue(value));
        }
    }
}
