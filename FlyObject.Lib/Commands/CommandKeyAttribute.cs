using System.Reflection;

namespace FlyObject.Lib.Commands;

public class CommandKeyAttribute : Attribute
{
    public char TestChar { get; }
    public CommandKeyAttribute(char testChar)
    {
        TestChar = testChar;
    }
}