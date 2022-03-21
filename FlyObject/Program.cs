// See https://aka.ms/new-console-template for more information

using System.Globalization;
using FlyObject;
using FlyObject.Lib;

var flyableManager = new ConsoleFlyableOperationManager();

flyableManager.Start();


var distance = ReadPointZ();

//Console.WriteLine($"Fly time - {flyable.Speed}");


PointZ? ReadPointZ()
{
    var pointsLine = Console.ReadLine();

    if (pointsLine == null) return null;
    
    return new PointZ(pointsLine);
}

