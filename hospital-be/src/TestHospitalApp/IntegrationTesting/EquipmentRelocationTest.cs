using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using Xunit;
using HospitalLibrary.MoveEquipment.Model;

namespace TestHospitalApp.IntegrationTesting
{
    public class EquipmentRelocationTest : BaseIntegrationTest
    {
        public EquipmentRelocationTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static MoveEquipmentAppointmentController SetupRenovationAppointmentController(IServiceScope scope)
        {
            return new MoveEquipmentAppointmentController(scope.ServiceProvider.GetRequiredService<IMoveEquipmentAppointmentService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }
        [Fact]
        public void Test_New_Move_Equipment_Appointment_1()
        {
            using var scope = Factory.Services.CreateScope();
            var moveEquipmentAppointmentController = SetupRenovationAppointmentController(scope);
            InputCreateData data = new InputCreateData();
            data.Date = DateTime.Now.AddDays(2);
            data.Amount = 1;
            data.Equipment = "a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0";
            data.Source = "18e98c94-5081-4020-ac91-d00f995c7e4f";
            data.Destination = "e2689a81-c248-4686-a807-5e6796a90857";
            var rv = moveEquipmentAppointmentController.Create(data);
            rv.ShouldNotBe(null); 
        }
        [Fact]
        public void Test_New_Move_Equipment_Appointment_2()
        {
            using var scope = Factory.Services.CreateScope();
            var moveEquipmentAppointmentController = SetupRenovationAppointmentController(scope);
            InputCreateData data = new InputCreateData();
            data.Date = DateTime.Now.AddDays(2);
            data.Amount = 1;
            data.Equipment = "497f7913-2139-4091-9a4c-0091d3b76216";
            data.Source = "e2689a81-c248-4686-a807-5e6796a90857";
            data.Destination = "18e98c94-5081-4020-ac91-d00f995c7e4f";
            var rv = moveEquipmentAppointmentController.Create(data);
            rv.ShouldNotBe(null); 
        }

        [Fact]
        public void Test_New_Move_Equipment_Appointment_3()
        {
            using var scope = Factory.Services.CreateScope();
            var moveEquipmentAppointmentController = SetupRenovationAppointmentController(scope);
            InputCreateData data = new InputCreateData();
            data.Date = DateTime.Now.AddDays(2);
            data.Amount = 3;
            data.Equipment = "497f7913-2139-4091-9a4c-0091d3b76216";
            data.Source = "18e98c94-5081-4020-ac91-d00f995c7e4f";
            data.Destination = "e2689a81-c248-4686-a807-5e6796a90857";
            var rv = moveEquipmentAppointmentController.Create(data);
            rv.ShouldNotBe(null); 
        }

        [Fact]
        public void Test_Wrong_RoomId_1()
        {
            using var scope = Factory.Services.CreateScope();
            var moveEquipmentAppointmentController = SetupRenovationAppointmentController(scope);
            InputCreateData data = new InputCreateData();
            data.Date = DateTime.Now.AddDays(2);
            data.Amount = 3;
            data.Equipment = "497f7913-2139-4091-9a4c-0091d3b76216";
            data.Source = "18e98c94-5081-4020-ac91-d00f995c7e4a";
            data.Destination = "e2689a81-c248-4686-a807-5e6796a90857";  
            Should.Throw<Microsoft.EntityFrameworkCore.DbUpdateException>(() => moveEquipmentAppointmentController.Create(data));       
        }

        [Fact]
        public void Test_Wrong_RoomId_2()
        {
            using var scope = Factory.Services.CreateScope();
            var moveEquipmentAppointmentController = SetupRenovationAppointmentController(scope);
            InputCreateData data = new InputCreateData();
            data.Date = DateTime.Now.AddDays(2);
            data.Amount = 3;
            data.Equipment = "497f7913-2139-4091-9a4c-0091d3b76216";
            data.Source = "18e98c94-5081-4020-ac91-d00f995c7e4f";
            data.Destination = "e2689a81-c248-4686-a807-5e6796a00857";  
            Should.Throw<Microsoft.EntityFrameworkCore.DbUpdateException>(() => moveEquipmentAppointmentController.Create(data));       
        }

    }
}
