using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;
using Shouldly;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class RoomRenovationPlanTest
    {
        [Fact]
        public void Room_Renovation_Plan_Success_1()
        {
            RoomRenovationPlan plan = new RoomRenovationPlan("Test","Test",1);
            plan.ShouldNotBe(null);
        }
        [Fact]
        public void Room_Renovation_Plan_Success_2()
        {
            RoomRenovationPlan plan = new RoomRenovationPlan("Room1","Baza",1337);
            plan.ShouldNotBe(null);
        }
        [Fact]
        public void Room_Renovation_Plan_Success_3()
        {
            RoomRenovationPlan plan = new RoomRenovationPlan("B","12",420);
            plan.ShouldNotBe(null);
        }
        [Fact]
        public void Room_Renovation_Plan_Success_4()
        {
            RoomRenovationPlan plan = new RoomRenovationPlan("Name43","Lorem ipsum",89);
            plan.ShouldNotBe(null);
        }
        [Fact]
        public void Room_Renovation_Plan_Fail_1()
        {
            Should.Throw<InvalidValueException>(() => new RoomRenovationPlan("","",0));
        }
        [Fact]
        public void Room_Renovation_Plan_Fail_2()
        {
            Should.Throw<InvalidValueException>(() => new RoomRenovationPlan("Test","",0));
        }
        [Fact]
        public void Room_Renovation_Plan_Fail_3()
        {
            Should.Throw<InvalidValueException>(() => new RoomRenovationPlan("","Test",0));
        }
        [Fact]
        public void Room_Renovation_Plan_Fail_4()
        {
            Should.Throw<InvalidValueException>(() => new RoomRenovationPlan("Test","Test",-5));
        }
        [Fact]
        public void Room_Renovation_Plan_Fail_5()
        {
            Should.Throw<InvalidValueException>(() => new RoomRenovationPlan("Test","",1));
        }
        [Fact]
        public void Room_Renovation_Plan_Fail_6()
        {
            Should.Throw<InvalidValueException>(() => new RoomRenovationPlan("","Test",1));
        }
    }
}