using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;
using FlyObject.Lib.Restrictions;

namespace FlyObject.Lib.Commands;

[CommandKey('M', "Set Flyable max speed")]
public class SetFlyableMaxSpeedCommand : IFlyableRequiredCommand, IFlyablePrinterCommand
{
    public IFlyable? Flyable { get; set; }

    public IFlyablePrinter Printer { get; set; }

    public IFlyable Execute()
    {
        if (Printer is null) throw new FlyableException("Printer is not specified");
        if (Flyable is null) throw new FlyableException("Flyable is not specified");
        Printer.WriteLine("Enter a max speed restriction:");
        var number = Printer.ReadNumber();
        Flyable.Restrictions.Add(new MaxSpeedRestriction(number));
        return Flyable;
    }
}