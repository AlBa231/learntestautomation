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
            return new XElement(GetXElementName(obj), GetPropertyXValue(obj));
        }

        private string GetXElementName(object obj)
        {
            if (obj is IDictionary dictionary) return dictionary.Values.GetType().GetGenericArguments().Last().Name;
            if (obj is IEnumerable list) return list.GetType().Name.Contains('`') ? list.GetType().GetGenericArguments().Last().Name + 's' : list.GetType().Name;
            return obj.GetType().Name;
        }

        private object GetPropertyXValue(object value)
        {
            return value.GetType().IsSimple() ? value : CreateChildNodes(value);
        }

        private IEnumerable<XElement> CreateChildNodes(object obj)
        {
            if (obj is IDictionary dictionary) return CreateChildNodesForDictionary(dictionary);
            if (obj is IEnumerable list) return CreateChildNodesForEnumerable(list);
            return CreateChildNodesForObject(obj);
        }

        private IEnumerable<XElement> CreateChildNodesForDictionary(IDictionary dictionary)
        {
            return from object key in dictionary.Keys select new XElement(key.ToString(), GetPropertyXValue(dictionary[key]));
        }

        private IEnumerable<XElement> CreateChildNodesForEnumerable(IEnumerable list)
        {
            return list.Cast<object>().Select(CreateXElement);
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
