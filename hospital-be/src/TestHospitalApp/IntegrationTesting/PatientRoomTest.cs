using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.BloodSupplies.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using Xunit;
using Shouldly;
using HospitalLibrary.Admissions.Model;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalAPI.Dtos.Bed;
using HospitalAPI.Dtos.Rooms;

namespace TestHospitalApp.IntegrationTesting
{
    public class PatientRoomTest : BaseIntegrationTest
    {
        public PatientRoomTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static PatientRoomController SetupPatientRoomController(IServiceScope scope)
        {
            return new PatientRoomController(scope.ServiceProvider.GetRequiredService<IPatientRoomService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Find_rooms_with_free_bed()
        {
            using var scope = Factory.Services.CreateScope();
            var patientRoomController = SetupPatientRoomController(scope);     

            
            
            List<PatientRoom> res = ((OkObjectResult)patientRoomController.GetRoomsWithFreeBeds())?.Value as List<PatientRoom>;
            res.ShouldNotBeNull();
        }

        
    }
}
