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
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Dtos.Renovation;

namespace TestHospitalApp.IntegrationTesting
{
    public class RenovationSessionTests : BaseIntegrationTest
    {
        public RenovationSessionTests(TestDatabaseFactory<Startup> factory) : base(factory){ }

        private static RenovationSessionController SetupRenovationAppointmentController(IServiceScope scope)
        {
            return new RenovationSessionController(scope.ServiceProvider.GetRequiredService<IRenovationSessionService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Test_New_Merge_Renovation_Good_1()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationAppointmentController.StartSession();
            Guid rootId = Guid.Parse(result.Value.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Merge"
            });

            List<RoomRenovationPlanDto> oldRooms = new List<RoomRenovationPlanDto>();
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            });
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "18e98c94-5081-4020-ac91-d00f995c7e4f"
            });
            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });

            List<RoomRenovationPlanDto> newRooms = new List<RoomRenovationPlanDto>();
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            });
            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });            

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(7),
                End = DateTime.Now.AddDays(8)
            });

            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(7),
                End = DateTime.Now.AddDays(8)
            });


            var rv = renovationAppointmentController.EndSession(rootId.ToString());
            rv.ShouldNotBe(null);
        }

        [Fact]
        public void Test_New_Merge_Renovation_Good_2()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationAppointmentController.StartSession();
            Guid rootId = Guid.Parse(result.Value.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Merge"
            });

            List<RoomRenovationPlanDto> oldRooms = new List<RoomRenovationPlanDto>();
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            });
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "18e98c94-5081-4020-ac91-d00f995c7e4f"
            });
            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });

            List<RoomRenovationPlanDto> newRooms = new List<RoomRenovationPlanDto>();
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            });
            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });            

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(10),
                End = DateTime.Now.AddDays(11)
            });

            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(10),
                End = DateTime.Now.AddDays(11)
            });


            var rv = renovationAppointmentController.EndSession(rootId.ToString());
            rv.ShouldNotBe(null);
        }

        [Fact]
        public void Test_New_Split_Renovation_Good_1()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationAppointmentController.StartSession();
            Guid rootId = Guid.Parse(result.Value.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Split"
            });

            List<RoomRenovationPlanDto> oldRooms = new List<RoomRenovationPlanDto>();
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            });

            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });

            List<RoomRenovationPlanDto> newRooms = new List<RoomRenovationPlanDto>();
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Desction233",
                Name = "Na8211",
                Number = 212
            });
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            });

            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });            

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(7),
                End = DateTime.Now.AddDays(8)
            });

            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(7),
                End = DateTime.Now.AddDays(8)
            });


            var rv = renovationAppointmentController.EndSession(rootId.ToString());
            rv.ShouldNotBe(null);
        }

        [Fact]
        public void Test_New_Split_Renovation_Good_2()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationAppointmentController.StartSession();
            Guid rootId = Guid.Parse(result.Value.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Split"
            });

            List<RoomRenovationPlanDto> oldRooms = new List<RoomRenovationPlanDto>();
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            });

            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });

            List<RoomRenovationPlanDto> newRooms = new List<RoomRenovationPlanDto>();
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Desction233",
                Name = "Na8211",
                Number = 212
            });
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            });

            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });            

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });


            var rv = renovationAppointmentController.EndSession(rootId.ToString());
            rv.ShouldNotBe(null);
        }

        [Fact]
        public void Test_New_Split_Renovation_Good_With_Returning_1()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationAppointmentController.StartSession();
            Guid rootId = Guid.Parse(result.Value.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Split"
            });

            renovationAppointmentController.ReturnToTypeSelection(rootId.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Split"
            });

            List<RoomRenovationPlanDto> oldRooms = new List<RoomRenovationPlanDto>();
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            });

            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });

            renovationAppointmentController.ReturnToOldRoomsSelection(rootId.ToString());

            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });

            List<RoomRenovationPlanDto> newRooms = new List<RoomRenovationPlanDto>();
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Desction233",
                Name = "Na8211",
                Number = 212
            });
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            });

            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });            

            renovationAppointmentController.ReturnToNewRoomCreation(rootId.ToString());

            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });     

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            renovationAppointmentController.ReturnToTimeframeCreation(rootId.ToString());

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            renovationAppointmentController.ReturnToSpecificTimeSelection(rootId.ToString());
            
            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            var rv = renovationAppointmentController.EndSession(rootId.ToString());
            rv.ShouldNotBe(null);
        }

        [Fact]
        public void Test_New_Split_Renovation_Good_With_Returning_2()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationAppointmentController.StartSession();
            Guid rootId = Guid.Parse(result.Value.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Split"
            });

            List<RoomRenovationPlanDto> oldRooms = new List<RoomRenovationPlanDto>();
            oldRooms.Add(new RoomRenovationPlanDto{
                Id = "fbcf2919-ef1c-49fe-9556-f99188bdbad9"
            });

            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });
        

            List<RoomRenovationPlanDto> newRooms = new List<RoomRenovationPlanDto>();
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Desction233",
                Name = "Na8211",
                Number = 212
            });
            newRooms.Add(new RoomRenovationPlanDto{
                Description = "Description233",
                Name = "Na8211",
                Number = 212
            });

            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });               

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            renovationAppointmentController.ReturnToSpecificTimeSelection(rootId.ToString());
            renovationAppointmentController.ReturnToTimeframeCreation(rootId.ToString());
            renovationAppointmentController.ReturnToNewRoomCreation(rootId.ToString());
            renovationAppointmentController.ReturnToOldRoomsSelection(rootId.ToString());
            renovationAppointmentController.ReturnToTypeSelection(rootId.ToString());

            renovationAppointmentController.ChooseType(new HospitalAPI.Dtos.RenovationSession.RenovationSessionTypeDto{
                AggregateId = rootId,
                Type = "Split"
            });

            renovationAppointmentController.ChooseOldRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = oldRooms
            });

            renovationAppointmentController.CreateNewRooms(new HospitalAPI.Dtos.RenovationSession.RenovationSessionRoomsDto{
                AggregateId = rootId,
                roomPlans = newRooms
            });  

            renovationAppointmentController.CreateTimeframe(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });
            
            renovationAppointmentController.ChooseSpecificTime(new HospitalAPI.Dtos.RenovationSession.RenovationSessionDateDto{
                AggregateId = rootId,
                Start = DateTime.Now.AddDays(11),
                End = DateTime.Now.AddDays(12)
            });

            var rv = renovationAppointmentController.EndSession(rootId.ToString());
            rv.ShouldNotBe(null);
        }
    }
}