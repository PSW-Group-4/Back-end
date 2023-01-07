using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Confluent.Kafka;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Swashbuckle.AspNetCore.SwaggerGen;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.UnitTesting.MedicalAppointmentSchedulingSessionTests
{
    public class MedicalAppointmentSchedulingStatisticsTest : BaseIntegrationTest
    {
        public MedicalAppointmentSchedulingStatisticsTest(TestDatabaseFactory<Startup> factory) : base(factory) { }



        [Fact]
        public void Gets_right_count_of_times_per_selection()
        {
            using var scope = Factory.Services.CreateScope();
            
            ControllerContext controllerContext = SetupControllerContext();
            MedAppSchedulingStatisticsController controller  = SetupMedAppSchedulingStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult) controller.GetTimesPerSelection();
            IDictionary<Selection, int> result = (IDictionary<Selection, int>) httpResult.Value;
            
            result[Selection.Date].ShouldBe(1);
            result[Selection.Speciality].ShouldBe(1);
            result[Selection.Date].ShouldBe(1);
            result[Selection.Date].ShouldBe(1);
        }


        [Fact]
        public void Gets_right_amount_of_time_spent_per_selection()
        {
            using var scope = Factory.Services.CreateScope();
            
            ControllerContext controllerContext = SetupControllerContext();
            MedAppSchedulingStatisticsController controller  = SetupMedAppSchedulingStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult) controller.GetSpentTimePerSelection();
            IDictionary<Selection, double> result = (IDictionary<Selection, double>) httpResult.Value;
            
            result[Selection.Date].ShouldBe(5);
            result[Selection.Speciality].ShouldBe(5);
            result[Selection.Doctor].ShouldBe(7.5);
            result[Selection.Time].ShouldBe(5);
        }
        
        
        [Fact]
        public void Gets_right_amount_of_total_time_spent_per_age_group()
        {
            using var scope = Factory.Services.CreateScope();
            
            ControllerContext controllerContext = SetupControllerContext();
            MedAppSchedulingStatisticsController controller  = SetupMedAppSchedulingStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult) controller.GetTotalSpentTimePerAgeGroup();
            IDictionary<string, double> result = (IDictionary<string, double>) httpResult.Value;
            
            //TODO Dynamically load age group labels
            result["Middle-aged adults(31 - 50)"].ShouldBe(25);
        }
        
        [Fact]
        public void Gets_right_amount_of_steps_per_age_group()
        {
            using var scope = Factory.Services.CreateScope();
            
            ControllerContext controllerContext = SetupControllerContext();
            MedAppSchedulingStatisticsController controller  = SetupMedAppSchedulingStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult) controller.GetTotalStepsPerAgeGroup();
            IDictionary<string, int> result = (IDictionary<string, int>) httpResult.Value;
            
            //TODO Dynamically load age group labels
            result["Middle-aged adults(31 - 50)"].ShouldBe(5);
        }
        
        [Fact]
        public void Gets_correct_scheduling_success_rate_per_age_group()
        {
            using var scope = Factory.Services.CreateScope();
            
            ControllerContext controllerContext = SetupControllerContext();
            MedAppSchedulingStatisticsController controller  = SetupMedAppSchedulingStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult) controller.GetSchedulingSuccessRatePerAgeGroup();
            IDictionary<string, double> result = (IDictionary<string, double>) httpResult.Value;
            
            //TODO Dynamically load age group labels
            result["Middle-aged adults(31 - 50)"].ShouldBe(50);
        }
        
        [Fact]
        public void Gets_right_number_of_chooses_per_doctor()
        {
            using var scope = Factory.Services.CreateScope();
            
            ControllerContext controllerContext = SetupControllerContext();
            MedAppSchedulingStatisticsController controller  = SetupMedAppSchedulingStatisticsController(scope, controllerContext);


            OkObjectResult httpResult = (OkObjectResult) controller.GetNumberOfChoosesPerDoctor();
            IDictionary<string, int> result = (IDictionary<string, int>) httpResult.Value;
            
            //TODO Dynamically load age group labels
            result["Test Doctor Sastanak Test Doctor Sastanak"].ShouldBe(3);
        }

        private MedAppSchedulingStatisticsController SetupMedAppSchedulingStatisticsController(IServiceScope scope, ControllerContext controllerContext)
        {
            MedAppSchedulingStatisticsController controller =
                new MedAppSchedulingStatisticsController(scope.ServiceProvider
                    .GetRequiredService<IMedAppSchedulingStatisticsService>());

            return controller;
        }

        private static ControllerContext SetupControllerContext()
        {
            //Manages jwt setup
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