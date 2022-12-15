using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using TestHospitalApp.Setup;
using Shouldly;
using HospitalAPI;
using AutoMapper;
using HospitalAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using HospitalLibrary.Renovation.Service.Interfaces;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Dtos.Renovation;




namespace TestHospitalApp.IntegrationTesting
{
    public class RenovationAppointmentTest : BaseIntegrationTest
    {
        public RenovationAppointmentTest(TestDatabaseFactory<Startup> factory) : base(factory){ }

        private static RenovationAppointmentController SetupRenovationAppointmentController(IServiceScope scope)
        {
            return new RenovationAppointmentController(scope.ServiceProvider.GetRequiredService<IRenovationAppointmentService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }
        [Fact]
        public void Test_New_Merge_Renovation()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            RenovationAppointmentDto dataDto = new RenovationAppointmentDto();
            dataDto.Room1 = new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            };
            dataDto.Room2 = new RoomRenovationPlanDto{
                Id = "18e98c94-5081-4020-ac91-d00f995c7e4f"
            };

            dataDto.Room3 = new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            };
            dataDto.StartTime = DateTime.Now.AddDays(3);
            dataDto.EndTime = DateTime.Now.AddDays(4);
            dataDto.Type = "Merge";
            var rv = renovationAppointmentController.Create(dataDto);
            rv.ShouldNotBe(null); 
        }
        [Fact]
        public void Test_New_Split_Renovation()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            RenovationAppointmentDto dataDto = new RenovationAppointmentDto();
            dataDto.Room1 = new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            };
            dataDto.Room2 = new RoomRenovationPlanDto{
                Description = "Desction233",
                Name = "Na8211",
                Number = 212
            };
            dataDto.Room3 = new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            };
            dataDto.StartTime = DateTime.Now.AddDays(3);
            dataDto.EndTime = DateTime.Now.AddDays(4);
            dataDto.Type = "Split";
            var rv = renovationAppointmentController.Create(dataDto);
            rv.ShouldNotBe(null); 
        }
        [Fact]
        public void Test_Cancel_Renovation_Appointment()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            List<RenovationAppointment> result = ((OkObjectResult)renovationAppointmentController.GetAll())?.Value as List<RenovationAppointment>;
            renovationAppointmentController.Delete(result.First().Id).ShouldNotBe(new NoContentResult()); 
        }
    }
}