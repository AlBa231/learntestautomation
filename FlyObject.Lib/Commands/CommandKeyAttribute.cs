namespace FlyObject.Lib.Commands;

public class CommandKeyAttribute : Attribute
{
    public char TestChar { get; }
    public string Description { get; }

    public CommandKeyAttribute(char testChar, string description)
    {
        TestChar = testChar;
        Description = description;
    }
}