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
using HospitalLibrary.Renovation.Service.Interfaces;



namespace TestHospitalApp.IntegrationTesting
{
    public class RenovationAppointmentTest : BaseIntegrationTest
    {
        public RenovationAppointmentTest(TestDatabaseFactory<Startup> factory) : base(factory){ }

        private static RenovationAppointmentController SetupRenovationAppointmentController(IServiceScope scope)
        {
            return new RenovationAppointmentController(scope.ServiceProvider.GetRequiredService<IRenovationAppointmentService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }
        [Fact]
        public void test()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationAppointmentController = SetupRenovationAppointmentController(scope);
            bool yes = true;
            yes.ShouldBe(true); 
        }
    }
}