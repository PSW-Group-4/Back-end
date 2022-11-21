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
    public class VacationRequestTest : BaseIntegrationTest
    {
        public VacationRequestTest(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static VacationController SetupVacationController(IServiceScope scope)
        {
            return new VacationController(scope.ServiceProvider.GetRequiredService<IVacationService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Return_current_vacations()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            List<Vacation> result = ((OkObjectResult)vacationController.GetDoctorVacationsFromSpecificStatus(VacationStatus.Waiting_For_Approval ,new Guid("5c036fba-1118-4f4b-b153-90d75e60625e")))?.Value as List<Vacation>;
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.First().VacationStatus.ShouldBe(VacationStatus.Waiting_For_Approval);
        }

        [Fact]
        public void Return_approved_vacations()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            List<Vacation> result = ((OkObjectResult)vacationController.GetDoctorVacationsFromSpecificStatus(VacationStatus.Approved, new Guid("5c036fba-1118-4f4b-b153-90d75e60625e")))?.Value as List<Vacation>;
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.First().VacationStatus.ShouldNotBe(VacationStatus.Waiting_For_Approval);
        }

        [Fact]
        public void Delete_vacation()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            var delete = ((NoContentResult)vacationController.Delete(new Guid("5c036fba-1128-4f4b-b153-90d75e60625e")));

            List<Vacation> result = ((OkObjectResult)vacationController.GetAll())?.Value as List<Vacation>;

            result.Count().ShouldBe(1);
        }

        [Fact]
        public void Dont_delete_wrong_vacation()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            var delete = ((NoContentResult)vacationController.Delete(new Guid("5c036fba-1138-4f4b-b153-90d75e60625e")));

            List<Vacation> result = ((OkObjectResult)vacationController.GetAll())?.Value as List<Vacation>;

            result.Count().ShouldBe(2);
        }

    }
}
