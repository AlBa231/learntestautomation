// See https://aka.ms/new-console-template for more information

using System.Globalization;
using FlyObject;
using FlyObject.Lib;

Console.WriteLine("Lets check speed of:");

Console.WriteLine("1 - Bird");
Console.WriteLine("2 - Plane");
Console.WriteLine("3 - Drone");

var flyable = SelectFlyable();

Console.WriteLine($"Selected {flyable.GetType().Name}");
Console.WriteLine($"Speed - {flyable.Speed}");

Console.WriteLine();
Console.WriteLine("Select operation:");
Console.WriteLine("1 - set fly start point");
Console.WriteLine("2 - calculate fly time");


var distance = ReadPointZ();

Console.WriteLine($"Fly time - {flyable.Speed}");


IFlyable SelectFlyable()
{
    return FlyableFactory.GetFlyable(Console.ReadKey().KeyChar);
}

PointZ ReadPointZ()
{
    var pointsLine = Console.ReadLine();

    if (pointsLine == null) throw new FlyableException("Point is not specified.");

    var points = pointsLine.Split(' ').Select(s => int.Parse(s, CultureInfo.InvariantCulture)).ToList();

    if (points.Count < 3) throw new FlyableException("Point is invalid.");

    return new PointZ(points[0], points[1], points[2]);
}

