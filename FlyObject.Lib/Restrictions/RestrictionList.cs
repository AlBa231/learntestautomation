using System.Collections;

namespace FlyObject.Lib.Restrictions
{
    public class RestrictionList: ICollection<IRestriction>
    {
        private readonly List<IRestriction> list = new();

        public void Add(IRestriction item)
        {
            list.RemoveAll(r => r.GetType() == item.GetType());
            list.Add(item);
        }

        public T? Find<T>() where T: IRestriction
        {
            return list.OfType<T>().FirstOrDefault();
        }

        public IEnumerator<IRestriction> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(IRestriction item)
        {
            return list.Contains(item);
        }

        public void CopyTo(IRestriction[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(IRestriction item)
        {
            return list.Remove(item);
        }

        public int Count => list.Count;
        public bool IsReadOnly => true;
    }
}
