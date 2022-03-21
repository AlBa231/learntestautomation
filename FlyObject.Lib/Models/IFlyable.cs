using FlyObject.Lib.Restrictions;

namespace FlyObject
{
    public interface IFlyable
    {
        int Speed { get; init; }

        public void FlyTo(PointZ newPoint);

        public double GetFlyTime(PointZ newPoint);

        public List<IRestriction> Restrictions { get; }
    }
}
