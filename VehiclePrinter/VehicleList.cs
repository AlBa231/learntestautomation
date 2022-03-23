using System.Collections;
using System.Xml.Serialization;
using VehiclePrinter.Exceptions;
using VehiclePrinter.Models;

namespace VehiclePrinter
{
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Scooter))]
    [Serializable]
    public class VehicleList : IList<Vehicle>
    {
        private readonly List<Vehicle> items;

        public VehicleList()
        {
            items = new List<Vehicle>();
        }

        public VehicleList(IEnumerable<Vehicle> collection)
        {
            items = new List<Vehicle>(collection);
        }

        public void Save(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Create);
            Save(fs);
        }

        public void Save(Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(VehicleList));

            serializer.Serialize(fileStream, this);
        }

        #region IList Members
        public void Add(Vehicle item)
        {
            if (item.Chassis == null)
                throw new VehicleAddException("Chassis cannot be null");
            if (item.Engine == null)
                throw new VehicleAddException("Engine cannot be null");
            if (item.Transmission == null)
                throw new VehicleAddException("Transmission cannot be null");
            items.Add(item);
        }

        public IEnumerator<Vehicle> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Vehicle item)
        {
            return items.Contains(item);
        }

        public void CopyTo(Vehicle[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Vehicle item)
        {
            return items.Remove(item);
        }

        public int Count => items.Count;
        public bool IsReadOnly => false;

        public int IndexOf(Vehicle item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, Vehicle item)
        {
            items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public Vehicle this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }
        #endregion
    }
}
