using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.MedicalAppointmentReportSession.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting.MedicalReportEventSourceTests
{
    public class CreateReportStatisticsTest : BaseIntegrationTest
    {
        public CreateReportStatisticsTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        [Fact]
        public void Gets_average_number_of_steps_to_create_report()
        {
            using var scope = Factory.Services.CreateScope();

            ControllerContext controllerContext = SetupControllerContext();
            MedAppReportStatisticsController controller = SetupMedAppReportStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult)controller.GetNumberSteps();
            IDictionary<string, int> result = (IDictionary<string, int>)httpResult.Value;

            result["Small"].ShouldBe(0);
            result["SmallNormal"].ShouldBe(6);
            result["BigNormal"].ShouldBe(0);
            result["Big"].ShouldBe(0);
        }


        [Fact]
        public void Gets_number_of_times_doctor_was_on_each_step()
        {
            using var scope = Factory.Services.CreateScope();

            ControllerContext controllerContext = SetupControllerContext();
            MedAppReportStatisticsController controller = SetupMedAppReportStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult)controller.GetNumberEachStep();
            IDictionary<SelectionReport, int> result = (IDictionary<SelectionReport, int>)httpResult.Value;

            result[SelectionReport.Symptom].ShouldBe(1);
            result[SelectionReport.ReportText].ShouldBe(1);
            result[SelectionReport.Medicine].ShouldBe(1);
            result[SelectionReport.Review].ShouldBe(1);
        }


        [Fact]
        public void Gets_average_time_spent_to_create_report()
        {
            using var scope = Factory.Services.CreateScope();

            ControllerContext controllerContext = SetupControllerContext();
            MedAppReportStatisticsController controller = SetupMedAppReportStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult)controller.GetTimeSteps();
            IDictionary<string, double> result = (IDictionary<string, double>)httpResult.Value;

            result["Small"].ShouldBe(0);
            result["SmallNormal"].ShouldBe(10);
            result["BigNormal"].ShouldBe(15);
            result["Big"].ShouldBe(0);
        }

        [Fact]
        public void Gets_average_time_spent_on_each_step()
        {
            using var scope = Factory.Services.CreateScope();

            ControllerContext controllerContext = SetupControllerContext();
            MedAppReportStatisticsController controller = SetupMedAppReportStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult)controller.GetTimeEachStep();
            IDictionary<SelectionReport, double> result = (IDictionary<SelectionReport, double>)httpResult.Value;

            result[SelectionReport.Symptom].ShouldBe(5);
            result[SelectionReport.ReportText].ShouldBe(5);
            result[SelectionReport.Medicine].ShouldBe(7.5);
            result[SelectionReport.Review].ShouldBe(5);
        }

        [Fact]
        public void Gets_number_of_steps_and_time_in_correlation_with_doctor_age()
        {
            using var scope = Factory.Services.CreateScope();

            ControllerContext controllerContext = SetupControllerContext();
            MedAppReportStatisticsController controller = SetupMedAppReportStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult)controller.GetDoctorTimeSteps();
            IDictionary<string, double> result = (IDictionary<string, double>)httpResult.Value;

            result["Small"].ShouldBe(25);
            result["SmallNormal"].ShouldBe(0);
            result["BigNormal"].ShouldBe(0);
            result["Big"].ShouldBe(0);
        }

        private MedAppReportStatisticsController SetupMedAppReportStatisticsController(IServiceScope scope, ControllerContext controllerContext)
        {
            return new MedAppReportStatisticsController(scope.ServiceProvider.GetRequiredService<IMedAppReportStatisticsService>()); ;
        }

        private static ControllerContext SetupControllerContext()
        {
            var identity = new GenericIdentity("Manager", "Federation");
            var contextUser = new ClaimsPrincipal(identity);
            identity.AddClaim(new Claim(type: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                value: "user"));
            var httpContext = new DefaultHttpContext()
            {
                User = contextUser
            };
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            return controllerContext;
        }
    }
}