using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands;

public interface IFlyableCommand
{
    public IFlyable? Flyable { get; set; }
    public void Execute();
}