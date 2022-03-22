using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands;

public interface IFlyableCommand
{
    public IFlyable Execute();
}


public interface IFlyableRequiredCommand: IFlyableCommand
{
    public IFlyable? Flyable { get; set; }
}