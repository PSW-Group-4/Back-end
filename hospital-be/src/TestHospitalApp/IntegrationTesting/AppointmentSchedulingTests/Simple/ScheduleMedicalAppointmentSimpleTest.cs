using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.Appointment;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Users.Service;
using HospitalLibrary.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting.AppointmentSchedulingTests.Simple
{
    public class ScheduleMedicalAppointmentSimpleTest : BaseIntegrationTest
    {
        public ScheduleMedicalAppointmentSimpleTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
        
        private static MedicalAppointmentController SetupMedicalAppointmentController(
            IServiceScope scope, ControllerContext controllerContext)
        {
            MedicalAppointmentController controller = new MedicalAppointmentController(scope.ServiceProvider.GetRequiredService<IMedicalAppointmentService>(),
                                                    scope.ServiceProvider.GetRequiredService<IMapper>(),
                                                    scope.ServiceProvider.GetRequiredService<IJwtService>(),
                                                    scope.ServiceProvider.GetRequiredService<IDoctorAppointmentService>(),
                                                    scope.ServiceProvider.GetRequiredService<IDoctorService>(),
                                                    scope.ServiceProvider.GetRequiredService<IUserService>())
            {
                ControllerContext = controllerContext
            };
            return controller;
        }

        [Fact]
        public void Gets_collection_of_available_appointment_times_which_has_3_members()
        {
            using var scope = Factory.Services.CreateScope();
            
            
            //user iz Jwt-a
            var identity = new GenericIdentity("Patient", "Federation");
            var contextUser = new ClaimsPrincipal(identity);
            identity.AddClaim(new Claim(type: "personId", value: "a6937bfe-0246-4e2b-94e1-4b8023ef3ea1"));
            identity.AddClaim(new Claim(type: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", value: "user"));
            var httpContext = new DefaultHttpContext()
            {
                User = contextUser
            };
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };
            //user iz Jwt-a
            
            var medicalAppointmentController = SetupMedicalAppointmentController(scope, controllerContext);

            var requestDto = SetAppointmentRequestDto();

            var result =(OkObjectResult) medicalAppointmentController.GetAvailableTerminsPatientSide(requestDto);
            var appointments = (List<DateRange>)result.Value;
            appointments.Count.ShouldBe(3);
        }

        private PatientSideAvailableAppointmentsRequestDto SetAppointmentRequestDto()
        {
            return new PatientSideAvailableAppointmentsRequestDto()
            {
                DoctorId = new Guid("5c125fba-1318-4f4b-b153-90d75e60626e"),
                Date = new DateTime(2022, 12, 26)
            };
        }
    }
}