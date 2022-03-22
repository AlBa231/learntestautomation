using FlyObject.Lib.FlyablePrinter;

namespace FlyObject.Test;

class TestDummyPrinter: IFlyablePrinter
{
    public void WriteLine(string str) { }

    public void WriteLine() { }

    public void Clear() { }

    public char ReadChar() => 'Q';

    public int ReadNumber() => 10;
    public string ReadLine() => "1 2 3";
}