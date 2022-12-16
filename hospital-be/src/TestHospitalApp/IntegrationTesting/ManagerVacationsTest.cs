using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Vacations.Model;
using HospitalLibrary.Vacations.Service;
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
    public class ManagerVacationsTest : BaseIntegrationTest
    {
        public ManagerVacationsTest(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static VacationController SetupVacationController(IServiceScope scope)
        {
            return new VacationController(scope.ServiceProvider.GetRequiredService<IVacationService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }


        [Fact]
        public void Return_onWait_test()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            List<Vacation> result = ((OkObjectResult)vacationController.GetDoctorVacationsFromSpecificStatus(VacationStatus.Waiting_For_Approval, new Guid("5c036fba-1118-4f4b-b153-90d75e60625e")))?.Value as List<Vacation>;
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.First().VacationStatus.ShouldBe(VacationStatus.Waiting_For_Approval);
        }

        [Fact]
        public void Return_approved_test()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            List<Vacation> result = ((OkObjectResult)vacationController.GetDoctorVacationsFromSpecificStatus(VacationStatus.Approved, new Guid("5c036fba-1118-4f4b-b153-90d75e60625e")))?.Value as List<Vacation>;
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
            result.First().VacationStatus.ShouldNotBe(VacationStatus.Waiting_For_Approval);
        }

        [Fact]
        public void Return_past_vacations()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            Vacation newVacation = new Vacation
            {
                Id = new Guid("361ed944-9243-400c-9198-85ff6a84fe7b"),
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateStart = new DateTime(2022, 01, 01),
                DateEnd = new DateTime(2022, 01, 04),
                Reason = "Test testa",
                Urgent = true,
                DeniedRequestReason = "",
                VacationStatus = VacationStatus.Approved
            };

            List<int> result = ((OkObjectResult)vacationController.GetAllPastByDoctorId(new Guid("5c036fba-1118-4f4b-b153-90d75e60625e")))?.Value as List<int>;
            
            result.ShouldNotBeNull();
            result.Count.ShouldBe(12);
            //result.First().VacationStatus.ShouldBe(VacationStatus.Approved);
        }

    }
}
