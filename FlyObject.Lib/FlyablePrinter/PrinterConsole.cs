namespace FlyObject.Lib.FlyablePrinter
{
    public interface IFlyablePrinter
    {
        public void WriteLine(string str);
        public void WriteLine();
        public void Clear();
        public char ReadChar();
        public int ReadNumber();
    }
}
