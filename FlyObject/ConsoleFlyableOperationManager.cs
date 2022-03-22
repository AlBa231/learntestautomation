using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyObject.Lib;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;

namespace FlyObject
{
    public class ConsoleFlyableOperationManager: FlyableOperationManager
    {
        private bool isWorking = true;

        public void Start()
        {
            
            while (isWorking)
            {
                PrintOperations();

                TryProcessOperation();
            }
        }

        public ConsoleFlyableOperationManager(IFlyablePrinter flyablePrinter) : base(flyablePrinter)
        {
        }
    }
}
