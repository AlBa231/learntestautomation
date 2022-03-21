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
    
    protected override double GetFlyTimeWithoutRestrictions(double distance)
    {
        var increaseCount = (int) distance / SpeedIncreaseDistance - 1;
        var avgSpeed = Speed + increaseCount * SpeedIncrease / 2;

        return Math.Round(distance / avgSpeed, 2);
    }
}