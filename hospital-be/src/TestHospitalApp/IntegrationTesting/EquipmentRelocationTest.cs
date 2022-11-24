using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.EquipmentRelocation.Service;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.SchedulingAppointment.Service;
using HospitalLibrary.Vacations.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting
{
    public class EquipmentRelocationTest : BaseIntegrationTest
    {
        public EquipmentRelocationTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static EquipmentRelocationController SetupMoveController(IServiceScope scope)
        {
            return new EquipmentRelocationController(scope.ServiceProvider.GetRequiredService<IEquipmentRelocationService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Return_current_move_requests()
        {
            using var scope = Factory.Services.CreateScope();
            var moveController = SetupMoveController(scope);

            List<EquipmentRelocationDTO> result = ((OkObjectResult)moveController.GetAll())?.Value as List<EquipmentRelocationDTO>;
            result.ShouldNotBeNull(); //treba baza da se napravi 
        }


    }
}
