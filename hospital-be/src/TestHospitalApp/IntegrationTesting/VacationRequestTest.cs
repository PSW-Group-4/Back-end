using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.Vacation;
using HospitalLibrary.Vacations.Model;
using HospitalLibrary.Vacations.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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
            result.Count.ShouldBe(3);
            result.First().VacationStatus.ShouldNotBe(VacationStatus.Waiting_For_Approval);
        }

        [Fact]
        public void Delete_vacation()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            var delete = ((NoContentResult)vacationController.Delete(new Guid("5c036fba-1128-4f4b-b153-90d75e60625e")));

            List<Vacation> result = ((OkObjectResult)vacationController.GetAll())?.Value as List<Vacation>;

            result.Count().ShouldBe(3);
        }

        [Fact]
        public void Dont_delete_wrong_vacation()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            var delete = ((NoContentResult)vacationController.Delete(new Guid("5c036fba-1138-4f4b-b153-90d75e60625e")));

            List<Vacation> result = ((OkObjectResult)vacationController.GetAll())?.Value as List<Vacation>;

            result.Count().ShouldBe(3);
        }

        // ovo bi trebalo da nij eimplementirano, ali fejluje zato sto nisu dodati apojntmenti
        [Fact]
        public void Create_urgent_vacation()
        {
            using var scope = Factory.Services.CreateScope();
            var vacationController = SetupVacationController(scope);

            VacationRequestDto vacationU = new VacationRequestDto()
            {
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateStart = new DateTime(2022, 12, 5, 0, 0, 0),
                DateEnd = new DateTime(2022, 12, 30, 0, 0, 0),
                Reason = "Zato sto mi je dodijalo",
                Urgent = true,
                VacationStatus = VacationStatus.Waiting_For_Approval,
                DeniedRequestReason = ""
            };

            Vacation newVacation = ((CreatedAtActionResult)vacationController.Create(vacationU))?.Value as Vacation;

            newVacation.Urgent.ShouldBeTrue();

            List<Vacation> result = ((OkObjectResult)vacationController.GetAll())?.Value as List<Vacation>;

            result.Count().ShouldBe(3);

        }

    }
}
