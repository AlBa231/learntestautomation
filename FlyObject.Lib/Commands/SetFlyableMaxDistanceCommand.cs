﻿using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;
using FlyObject.Lib.Restrictions;

namespace FlyObject.Lib.Commands;

[CommandKey('T', "Set Flyable max distance")]
public class SetFlyableMaxDistanceCommand : IFlyableRequiredCommand, IFlyablePrinterCommand
{
    public IFlyable? Flyable { get; set; }

    public IFlyablePrinter Printer { get; set; }

    public IFlyable Execute()
    {
        if (Printer is null) throw new FlyableException("Printer is not specified");
        if (Flyable is null) throw new FlyableException("Flyable is not specified");
        Printer.WriteLine();
        Printer.WriteLine("Enter a max distance restriction:");
        var number = Printer.ReadNumber();
        Flyable.Restrictions.Add(new MaxDistanceRestriction(number));
        return Flyable;
    }
}


[CommandKey('G', "Get fly time to...")]
public class GetFlyTimeToCommand : IFlyableRequiredCommand, IFlyablePrinterCommand
{
    public IFlyable? Flyable { get; set; }

    public IFlyablePrinter Printer { get; set; }

    public IFlyable Execute()
    {
        if (Printer is null) throw new FlyableException("Printer is not specified");
        if (Flyable is null) throw new FlyableException("Flyable is not specified");
        Printer.WriteLine();
        Printer.WriteLine("Enter a X Y Z for new point:");
        var newPoint = new PointZ(Printer.ReadLine());
        var time = Flyable.GetFlyTime(newPoint);
        Printer.WriteLine();
        Printer.WriteLine("The time for fly is " + time);
        return Flyable;
    }
}