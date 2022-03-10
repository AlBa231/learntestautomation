using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class VehicleGeneratorTests
    {
        [Fact]
        public void TestVehicleFactory_CreateCar()
        {
            var car = VehicleFactory.CreateCar();
            
            Assert.Equal(@"Toyota Camry 2.4 (170 hp), Gasoline (2AZ-FE).
4 wheels, 570 kg, 231000В0102526,
Automatic, 5 gears, Aisin Japan", car.ToString());
        }
    }
}
