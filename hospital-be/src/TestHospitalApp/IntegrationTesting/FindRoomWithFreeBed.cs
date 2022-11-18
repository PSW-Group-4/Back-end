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

namespace TestHospitalApp.IntegrationTesting
{
    public class FindRoomWithFreeBed : BaseIntegrationTest
    {
        public FindRoomWithFreeBed(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static DoctorRoomController SetupDoctorRoomController(IServiceScope scope)
        {
            return new DoctorRoomController(scope.ServiceProvider.GetRequiredService<IDoctorRoomService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Return_all_rooms_with_free_bed()
        {
            using var scope = Factory.Services.CreateScope();
            var admissionController = SetupDoctorRoomController(scope);

            IEnumerable<DoctorRoom> result = ((OkObjectResult)admissionController.FindRoomsWithFreeBed())?.Value as IEnumerable<DoctorRoom>;
            result.ShouldNotBeNull();
        }
    }
}