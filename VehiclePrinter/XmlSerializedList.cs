using System.Xml.Serialization;

namespace VehiclePrinter
{
    [Serializable]
    public abstract class XmlSerializedList<T>: List<T>
    {
        public abstract List<T> Items { get; set; }

        public void Save(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Create);
            Save(fs);
        }

        public void Save(Stream fileStream)
        {
            var serializer = new XmlSerializer(GetType());

            serializer.Serialize(fileStream, this);
        }
    }
}
