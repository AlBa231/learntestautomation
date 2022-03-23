using VehiclePrinter.Exceptions;
using Xunit;

namespace VehiclePrinter.Test;

public class VehicleListRemoveTests
{
    [Fact]
    public void TestRemoveAutoOk()
    {
        var vehicleList = RandomVehicleFactory.CreateRandomVehicles(10);
        var car = vehicleList[5];

        vehicleList.RemoveById(car.Id);

        Assert.DoesNotContain(car, vehicleList);
    }

    [Fact]
    public void TestRemoveAutoException()
    {
        var vehicleList = new VehicleList();

        Assert.Throws<VehicleRemoveAutoException>(() => vehicleList.RemoveById("bad"));
    }
}