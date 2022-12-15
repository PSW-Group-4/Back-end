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

namespace TestHospitalApp.IntegrationTesting.AppointmentSchedulingTests.WithSuggestions
{
    public class ScheduleAppointmentWithSuggestionsTest : BaseIntegrationTest
    {
        public ScheduleAppointmentWithSuggestionsTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        /*private static SchedulingController SetupSchedulingController(IServiceScope scope)
        {
            return new SchedulingController(scope.ServiceProvider.GetRequiredService<IDoctorAppointmentService>(),
                                            scope.ServiceProvider.GetRequiredService<IAppointmentService>(),
                                            scope.ServiceProvider.GetRequiredService<IMapper>(),
                                            scope.ServiceProvider.GetRequiredService<IJwtService>());
        }*/

        private static MedicalAppointmentController SetupMedicalAppointmentController(IServiceScope scope)
        {
            return new MedicalAppointmentController(scope.ServiceProvider.GetRequiredService<IMedicalAppointmentService>(),
                                                    scope.ServiceProvider.GetRequiredService<IMapper>(),
                                                    scope.ServiceProvider.GetRequiredService<IJwtService>(),
                                                    scope.ServiceProvider.GetRequiredService<IDoctorAppointmentService>());
        }

        [Fact]
        public void Test_Schedule_Appointment()
        {
            using var scope = Factory.Services.CreateScope();
            //var schedulingController = SetupSchedulingController(scope);
            var medicalAppointmentController = SetupMedicalAppointmentController(scope);

            var requestForSuggestions = SetupRequestForSuggestionsDtos();

            List<DateRange> suggestions = ((OkObjectResult)medicalAppointmentController.GetAppointmentSuggestions(
                requestForSuggestions))?.Value as List<DateRange>;

            var requestForScheduling = SetupRequestForSchedulingDtos(requestForSuggestions, suggestions[0]);

            MedicalAppointment result = ((OkObjectResult)medicalAppointmentController.Create(
                requestForScheduling))?.Value as MedicalAppointment;        //mozda ne moze ovako

            result.ShouldNotBeNull();
        }

        private AppointmentRequestWithSuggestionsDto SetupRequestForSuggestionsDtos()
        {
            var result = new AppointmentRequestWithSuggestionsDto();

            var requestTimeRange = new DateRangeDto();
            requestTimeRange.StartTime = new DateTime();        //promeni
            requestTimeRange.EndTime = new DateTime();          //promeni

            result.RequestTimeRange = requestTimeRange;
            result.DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e");              
            result.Priority = "Doctor";

            return result;
        }

        private AppointmentRequestDto SetupRequestForSchedulingDtos(AppointmentRequestWithSuggestionsDto requestForSuggestions,
            DateRange suggestion)
        {
            var result = new AppointmentRequestDto();
            result.StartTime = suggestion.StartTime;
            result.PatientId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e");      //promeni
            result.DoctorId = requestForSuggestions.DoctorId;
            result.RoomId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e");     //promeni

            return result;
        }
    }
}
