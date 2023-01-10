using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class MapLocationTest
    {
        [Fact]
        public void MapLocationConstructor_CoordinateXNegative_False()
        {
            int CoordinateX = -12;
            int CoordinateY = 50;
            int Height = 30;
            int Width = 30;
            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                MapLocation mapLocation = new MapLocation(CoordinateX, CoordinateY, Height,Width);
            });
        }

        [Fact]
        public void MapLocationConstructor_CoordinateYNegative_False()
        {
            int CoordinateX = 100;
            int CoordinateY = -50;
            int Height = 30;
            int Width = 30;
            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                MapLocation mapLocation = new MapLocation(CoordinateX, CoordinateY, Height, Width);
            });
        }

        [Fact]
        public void MapLocationConstructor_HeightNegative_False()
        {
            int CoordinateX = 100;
            int CoordinateY = 50;
            int Height = -30;
            int Width = 30;
            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                MapLocation mapLocation = new MapLocation(CoordinateX, CoordinateY, Height, Width);
            });
        }

        [Fact]
        public void MapLocationConstructor_WidthNegative_False()
        {
            int CoordinateX = 100;
            int CoordinateY = 50;
            int Height = 30;
            int Width = -30;
            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                MapLocation mapLocation = new MapLocation(CoordinateX, CoordinateY, Height, Width);
            });
        }

        [Fact]
        public void MapLocationConstructor_AllFieldsPositive_True()
        {
            int CoordinateX = 100;
            int CoordinateY = 50;
            int Height = 30;
            int Width = 30;
            MapLocation mapLocation = new MapLocation(CoordinateX, CoordinateY, Height, Width);
            Assert.NotNull(mapLocation);
        }
    }
}
