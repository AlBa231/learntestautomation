namespace FlyObject;

public record PointZ(int X, int Y, int Z)
{
    public static PointZ operator -(PointZ a, PointZ b)
    {
        return new PointZ(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }
}