using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.MoveEquipment.Model;
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
    public class MoveEquipmentTest : BaseIntegrationTest
    {
        public MoveEquipmentTest(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static MoveEquipmentTaskController SetupMoveEquipmentController(IServiceScope scope)
        {
            return new MoveEquipmentTaskController(scope.ServiceProvider.GetRequiredService<IMoveEquipmentTaskService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

       /* [Fact]
        public void Create_move_task()
        {
            using var scope = Factory.Services.CreateScope();
            var moveController = SetupMoveEquipmentController(scope);

            InputCreateData task1 = new InputCreateData()
            {
                Source = "Soba 201",
                Destination = "Podrum",
                Amount = 10,
                Date = new DateTime(2022, 12, 5, 0, 0, 0),
                Duration = 30
            };

            MoveEquipmentTask newTask = ((OkObjectResult)moveController.Create2(task1))?.Value as MoveEquipmentTask;

            List<MoveEquipmentTask> tasks = ((OkObjectResult)moveController.GetAll())?.Value as List<MoveEquipmentTask>;

            tasks.Count().ShouldBe(2);

            //newTask.ShouldNotBeNull();
        }*/

        /*[Fact]
        public void Return_all_tasks()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupMoveEquipmentController(scope);

            //List<MoveEquipmentTask> result = ((OkObjectResult)controller.GetAll())?.Value as List<MoveEquipmentTask>;
            result.ShouldNotBeNull();
        }*/
    }
}
