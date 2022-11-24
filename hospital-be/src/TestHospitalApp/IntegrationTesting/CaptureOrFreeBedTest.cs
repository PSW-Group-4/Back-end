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

namespace TestHospitalApp.IntegrationTesting
{
    public class CaptureOrFreeBedTest : BaseIntegrationTest
    {
        public CaptureOrFreeBedTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static BedController SetupBedController(IServiceScope scope)
        {
            return new BedController(scope.ServiceProvider.GetRequiredService<IBedService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Capture_free_bed()
        {
            using var scope = Factory.Services.CreateScope();
            var bedController = SetupBedController(scope);

            var bed1 = new BedDto
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e606251"),
                IsFree = true,
                equipmentId = new Guid("5c036fba-1118-4f4b-b153-90d75e606299"),
                equipment = null,
            };

            Bed bed = ((OkObjectResult)bedController.CaptureBed(bed1))?.Value as Bed;
            bed.IsFree.ShouldBeFalse();
        }

        [Fact]
        public void Free_captured_bed()
        {
            using var scope = Factory.Services.CreateScope();
            var bedController = SetupBedController(scope);

            var bed1 = new BedDto
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e606251"),
                IsFree = false,
                equipmentId = new Guid("5c036fba-1118-4f4b-b153-90d75e606299"),
                equipment = null,
            };

            Bed bed = ((OkObjectResult)bedController.FreeBed(bed1))?.Value as Bed;
            bed.IsFree.ShouldBeTrue();
        }
    }
}
