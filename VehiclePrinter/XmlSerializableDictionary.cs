using System.Xml.Serialization;

namespace VehiclePrinter
{
    [XmlRoot("Dictionary")]
    public class XmlSerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable
    {
        private readonly XmlSerializer _keySerializer = new XmlSerializer(typeof(TKey));
        private readonly XmlSerializer _valueSerializer = new XmlSerializer(typeof(TValue));

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                TKey key = (TKey)_keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue value = (TValue)_valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                if (!this.ContainsKey(key))
                    this.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                _keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                TValue value = this[key];
                _valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}
