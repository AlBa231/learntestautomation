using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyObject.Lib;
using FlyObject.Lib.Models;

namespace FlyObject
{
    public class ConsoleFlyableOperationManager: FlyableOperationManager
    {
        private bool isWorking = true;
        private IFlyable? currentFlyable;

        public void Start()
        {
            
            while (isWorking)
            {
                PrintOperations();

                TryProcessOperation();
            }
        }

        private void PrintOperations()
        {
            Console.Clear();
            Console.WriteLine("Lets check speed of:");

            Console.WriteLine("1 - Bird");
            Console.WriteLine("2 - Plane");
            Console.WriteLine("3 - Drone");

            Console.WriteLine("Q - Quit");

            Console.WriteLine();
        }

        private void TryProcessOperation()
        {
            try
            {
                ProcessOperation();
            }
            catch (FlyableException e)
            {
                Console.WriteLine($"Error - {e.Message}. Return to main menu.");
            }
        }

        private void ProcessOperation()
        {
            var commandKey = Console.ReadKey().KeyChar;

            if (commandKey is 'Q' or 'q')
            {
                isWorking = false;
                return;
            }

            currentFlyable = FlyableFactory.GetFlyable(commandKey);

            PrintFlyableInfo();

            var flyableCommand = Console.ReadKey();
        }

        private void PrintFlyableInfo()
        {
            Console.Clear();
            Console.WriteLine($"Selected {currentFlyable.GetType().Name}");
            Console.WriteLine($"Speed - {currentFlyable.Speed}");

            Console.WriteLine();
            Console.WriteLine("Select operation:");
            Console.WriteLine("1 - set fly start point");
            Console.WriteLine("2 - calculate fly time");
            Console.WriteLine("3 - set fly speed");

            //custom commands
            //bird
            Console.WriteLine("4 - set fly speed");
        }
    }
}
