using FlyObject.Lib;

namespace FlyObject;

public record PointZ(int X, int Y, int Z)
{
    public PointZ(int[] points) : this(points[0], points[1], points[2]){}

    public PointZ(string xyzBySpaces):this(xyzBySpaces.ToIntArray()) { }
    

    /// <summary>
    /// Find distance between two points.
    /// </summary>
    /// <returns></returns>
    public static double operator -(PointZ start, PointZ end)
    {
        var x = start.X - end.X;
        var y = start.Y - end.Y;
        var z = start.Z - end.Z;
        return Math.Round(Math.Sqrt(x * x + y * y + z * z), 2);
    }
}