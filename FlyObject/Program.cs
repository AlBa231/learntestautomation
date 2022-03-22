// See https://aka.ms/new-console-template for more information

using FlyObject;

var flyableManager = new ConsoleFlyableOperationManager(new FlyableConsolePrinter());

flyableManager.Start();


var distance = ReadPointZ();

//Console.WriteLine($"Fly time - {flyable.Speed}");


PointZ? ReadPointZ()
{
    var pointsLine = Console.ReadLine();

    if (pointsLine == null) return null;
    
    return new PointZ(pointsLine);
}

