namespace FlyObject;

public class Plane : Flyable
{
    private const int SpeedIncreaseDistance = 10;
    private const int SpeedIncrease = 10;
    private const int DefaultStartSpeed = 200;

    public Plane()
    {
        Speed = DefaultStartSpeed;
    }

    public override double GetFlyTime(PointZ newPoint)
    {
        var diff = newPoint - CurrentPosition;

        var increaseCount = (int) diff / SpeedIncreaseDistance - 1;
        var avgSpeed = Speed + increaseCount * SpeedIncrease / 2;

        return Math.Round(diff / avgSpeed, 2);
    }
}