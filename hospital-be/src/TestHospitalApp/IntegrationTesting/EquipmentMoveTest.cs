using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.AdmissionHistories.Service;
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
    public class EquipmentMoveTest : BaseIntegrationTest
    {
        public EquipmentMoveTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static MoveEquipmentTaskController SetupMoveController(IServiceScope scope)
        {
            return new MoveEquipmentTaskController(scope.ServiceProvider.GetRequiredService<IMoveEquipmentTaskService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Return_current_move_requests()
        {
            using var scope = Factory.Services.CreateScope();
            var moveController = SetupMoveController(scope);

            List<Vacation> result = ((OkObjectResult)moveController.(VacationStatus.Waiting_For_Approval, new Guid("5c036fba-1118-4f4b-b153-90d75e60625e")))?.Value as List<Vacation>;
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.First().VacationStatus.ShouldBe(VacationStatus.Waiting_For_Approval);
        }


    }
}
