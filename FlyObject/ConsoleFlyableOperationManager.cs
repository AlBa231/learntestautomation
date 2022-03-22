using FlyObject.Lib;
using FlyObject.Lib.FlyablePrinter;

namespace FlyObject
{
    public class ConsoleFlyableOperationManager: FlyableOperationManager
    {
        private bool isWorking = true;

        public void Start()
        {
            
            while (isWorking)
            {
                TryProcessOperation();
            }
        }

        public ConsoleFlyableOperationManager(IFlyablePrinter flyablePrinter) : base(flyablePrinter)
        {
        }
    }
}
