using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.Appointment;
using HospitalAPI.Dtos.DateRange;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Users.Service;
using HospitalLibrary.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting.AppointmentSchedulingTests.WithSuggestions
{
    public class ScheduleAppointmentWithSuggestionsTest : BaseIntegrationTest
    {
        public ScheduleAppointmentWithSuggestionsTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static MedicalAppointmentController SetupMedicalAppointmentController(
            IServiceScope scope, ControllerContext controllerContext)
        {
            var test = new MedicalAppointmentController(scope.ServiceProvider.GetRequiredService<IMedicalAppointmentService>(),
                                                    scope.ServiceProvider.GetRequiredService<IMapper>(),
                                                    scope.ServiceProvider.GetRequiredService<IJwtService>(),
                                                    scope.ServiceProvider.GetRequiredService<IDoctorAppointmentService>(),
                                                    scope.ServiceProvider.GetRequiredService<IDoctorService>(),
                                                    scope.ServiceProvider.GetRequiredService<IUserService>())
            {
                ControllerContext = controllerContext
            };
            return test;
        }

        [Fact]
        public void Test_Schedule_Appointment()
        {
            using var scope = Factory.Services.CreateScope();
            //user iz Jwt-a
            var identity = new GenericIdentity("Patient", "Federation");
            var contextUser = new ClaimsPrincipal(identity);
            identity.AddClaim(new Claim(type: "personId", value: "f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"));
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

            var requestForSuggestions = SetupRequestForSuggestionsDtos();

            List<AppointmentSuggestionsWithTheirDoctors> suggestions = 
                ((OkObjectResult)medicalAppointmentController.GetAppointmentSuggestions(
                requestForSuggestions))?.Value as List<AppointmentSuggestionsWithTheirDoctors>;

            var requestForScheduling = SetupRequestForSchedulingDtos(requestForSuggestions, suggestions[0]);

            var result = medicalAppointmentController.ScheduleAppointmentPatient(
                requestForScheduling);        //mozda ne moze ovako

            result.ShouldNotBeNull();
        }

        private AppointmentRequestWithSuggestionsDto SetupRequestForSuggestionsDtos()
        {
            var result = new AppointmentRequestWithSuggestionsDto();

            result.StartDate = new DateTime();
            result.EndDate = result.StartDate.AddMinutes(30) ;
            result.DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e");              
            result.Priority = "Doctor";

            return result;
        }

        private AppointmentRequestPatientDto SetupRequestForSchedulingDtos(
            AppointmentRequestWithSuggestionsDto requestForSuggestions, AppointmentSuggestionsWithTheirDoctors suggestion)
        {
            var result = new AppointmentRequestPatientDto();
            result.Date = suggestion.appointmentSuggestions.StartTime;
            result.DoctorId = requestForSuggestions.DoctorId;

            return result;
        }
    }
}
