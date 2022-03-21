namespace FlyObject
{
    public interface IFlyable
    {
        public void FlyTo(PointZ newPoint);

        public double GetFlyTime(PointZ newPoint);
    }
}
