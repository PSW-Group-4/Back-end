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
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalAPI.Dtos.Renovation;




namespace TestHospitalApp.IntegrationTesting
{
    public class RenovationSessionStatisticsTests : BaseIntegrationTest
    {
        public RenovationSessionStatisticsTests(TestDatabaseFactory<Startup> factory) : base(factory){ }

        private static RenovationSessionStatisticsController SetupRenovationAppointmentController(IServiceScope scope)
        {
            return new RenovationSessionStatisticsController(scope.ServiceProvider.GetRequiredService<IRenovationSessionStatisticsService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Test_Get_Average_Number_Of_Times_Went_Back_Per_Step()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationStatisticsController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationStatisticsController.GetAverageNumberOfTimesWentBackPerStep();
            result.ShouldNotBe(null);
        }

        [Fact]
        public void Test_Get()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationStatisticsController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationStatisticsController.GetAverageTimeSpentOnStepsInSession();
            result.ShouldNotBe(null);
        }

        [Fact]
        public void Test_Get_Average_Time_Spent_On_Steps_In_Session_For_Timeframe()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationStatisticsController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationStatisticsController.GetAverageTimeSpentOnStepsInSessionForTimeframe("0","23");
            result.ShouldNotBe(null);
        }

        [Fact]
        public void Test_Get_Finished_And_Unfinished_Session_Statistic()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationStatisticsController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationStatisticsController.GetFinishedAndUnfinishedSessionStatistic();
            result.ShouldNotBe(null);
        }

        [Fact]
        public void Test_Get_Finished_Session_Statistics_For_Table()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationStatisticsController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationStatisticsController.GetFinishedSessionStatisticsForTable();
            result.ShouldNotBe(null);
        }

        [Fact]
        public void Test_Get_Number_Of_Session_Left_Off_On_Each_Step()
        {
            using var scope = Factory.Services.CreateScope();
            var renovationStatisticsController = SetupRenovationAppointmentController(scope);
            OkObjectResult result = (OkObjectResult) renovationStatisticsController.GetNumberOfSessionLeftOffOnEachStep();
            result.ShouldNotBe(null);
        }
    }
}