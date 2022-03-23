﻿using VehiclePrinter.Models;

namespace VehiclePrinter
{
    public static class VehicleFactory
    {
        public static Car CreateCar()
        {
            var engine = new VehicleEngine
            {
                Power = 170,
                Capacity = 2362,
                Type = EngineType.Gasoline,
                SerialNumber = "2AZ-FE"
            };

            var chassis = new VehicleChassis
            {
                WheelCount = 4,
                Number = "231000В0102526",
                MaxLoad = 570
            };

            var transmission = new Transmission
            {
                Type = TransmissionType.Automatic,
                GearsNumber = 5,
                Manufacturer = "Aisin Japan"
            };

            return new Car
            {
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission,
                Model = "Camry",
                Make = "Toyota"
            };
        }

        public static Truck CreateTruck()
        {
            var engine = new VehicleEngine
            {
                Power = 420,
                Capacity = 12740,
                Type = EngineType.Diesel,
                SerialNumber = "1AASDTZ-F34FwaE"
            };

            var chassis = new VehicleChassis
            {
                WheelCount = 9,
                Number = "83250D0102526",
                MaxLoad = 15205
            };

            var transmission = new Transmission
            {
                Type = TransmissionType.Manual,
                GearsNumber = 16,
                Manufacturer = "Smart Electronic"
            };

            return new Truck
            {
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission,
                Model = "Cargo",
                Make = "Ford",
                Height = 3245,
                Width = 2540
            };
        }

        public static Bus CreateBus()
        {

            var engine = new VehicleEngine
            {
                Power = 320,
                Capacity = 10760,
                Type = EngineType.Diesel,
                SerialNumber = "2ABSSTZ-F34AAS11"
            };

            var chassis = new VehicleChassis
            {
                WheelCount = 12,
                Number = "2315321D02321E",
                MaxLoad = 14384
            };

            var transmission = new Transmission
            {
                Type = TransmissionType.Manual,
                GearsNumber = 6,
                Manufacturer = "Alarus Megatronics"
            };

            return new Bus
            {
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission,
                Model = "695",
                Make = "Ikarus",
                PassengerSeatCount = 50,
                HandicappedSeatCount = 2,
                HasToilet = true
            };
        }

        public static Scooter CreateScooter()
        {
            var engine = new VehicleEngine
            {
                Power = 8,
                Capacity = 125,
                Type = EngineType.Gasoline,
                SerialNumber = "2ABS22Z-F3123AS11"
            };

            var chassis = new VehicleChassis
            {
                WheelCount = 2,
                Number = "1235324402321E",
                MaxLoad = 180
            };

            var transmission = new Transmission
            {
                Type = TransmissionType.Manual,
                GearsNumber = 2,
                Manufacturer = "CHOHO 428"
            };

            return new Scooter
            {
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission,
                Model = "Alfa",
                Make = "MUSSTANG",
                HasAlarm = true,
                SeatCount = 1
            };
        }
    }
}
