using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.Vacation;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.MoveEquipment.Service.Implementation;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
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
    public class EquipmentToMoveTest : BaseIntegrationTest
    {
        public EquipmentToMoveTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static EquipmentToMoveService SetupEquipmentToMoveService(IServiceScope scope)
        {
            return new EquipmentToMoveService(scope.ServiceProvider.GetRequiredService<IEquipmentToMoveService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Create_equipment()
        {
            using var scope = Factory.Services.CreateScope();
            var equipmentController = SetupEquipmentToMoveService(scope);

            EquipmentToMove newEq = new EquipmentToMove()
            {
                Id = new Guid("3d474214-780c-46a8-8fdd-fc55251f936a"),
                EquipmentId = new Guid("5c036fba-1118-4f4b-b153-90d75e606299"),
                Amount = 10
            };

            var eq = equipmentController.Create(newEq);

            List<EquipmentToMove> result = ((OkObjectResult)equipmentController.GetAll())?.Value as List<EquipmentToMove>;

            result.Count.ShouldBe(3);

        }
    }
}
