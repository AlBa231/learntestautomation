﻿using FlyObject.Lib.Models;
using Xunit;

namespace FlyObject.Test
{
    public class PlaneTests
    {
        [Fact]
        public void TestGetFlyTimeForPlaneSmallDistance()
        {
            var plane = new Plane
            {
                Speed = 200
            };

            var startPoint = new PointZ(10, 10, 10);
            var endPoint = new PointZ(50, 10, 10);

            plane.FlyTo(startPoint);
            Assert.Equal(0.19, plane.GetFlyTime(endPoint));
        }

        [Fact]
        public void TestGetFlyTimeForPlane()
        {
            var plane = new Plane
            {
                Speed = 200
            };

            var startPoint = new PointZ(10, 10, 10);
            var endPoint = new PointZ(260, 360, 710);

            plane.FlyTo(startPoint);
            Assert.Equal(1.36, plane.GetFlyTime(endPoint));

            
        }
    }
}
