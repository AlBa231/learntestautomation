using FlyObject.Lib.FlyablePrinter;

namespace FlyObject
{
    internal class FlyableConsolePrinter: IFlyablePrinter
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public char ReadChar()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
