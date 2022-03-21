using FlyObject.Lib.Restrictions;

namespace FlyObject.Lib.Models
{
    public interface IFlyable
    {
        int Speed { get; init; }

        public void FlyTo(PointZ newPoint);

        public double GetFlyTime(PointZ newPoint);

        public RestrictionList Restrictions { get; }
    }
}
