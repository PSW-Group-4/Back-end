using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.BloodConsumptionRecords.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using AutoMapper;
using Xunit;
using HospitalAPI.Dtos.BloodConsumptionRecord;
using HospitalLibrary.BloodSupplies.Service;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodConsumptionRecords.Model;

namespace TestHospitalApp.IntegrationTesting
{
    public class CreateBloodConsumptionRecordTest : BaseIntegrationTest
    {
        public CreateBloodConsumptionRecordTest(TestDatabaseFactory<Startup> factory) : base(factory) {}
        
        private static BloodConsumptionRecordController SetupBloodConsumptionRecordController(IServiceScope scope)
        {
            return new BloodConsumptionRecordController(scope.ServiceProvider.GetRequiredService<IBloodConsumptionRecordService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        private static BloodSupplyController SetupBloodSupplyController(IServiceScope scope)
        {
            return new BloodSupplyController(scope.ServiceProvider.GetRequiredService<IBloodSupplyService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Reduces_blood_in_database()
        {
            using var scope = Factory.Services.CreateScope();
            var bloodConsumptionRecordController = SetupBloodConsumptionRecordController(scope);
            var bloodSupplyController = SetupBloodSupplyController(scope);
            var bloodConsumptionRecord = new BloodConsumptionRecordRequestDto
            {
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Amount = new Amount(50.0),
                BloodType = "A+",
                Reason = "Reason 1"
            };

            var createdRecord = bloodConsumptionRecordController.Create(bloodConsumptionRecord);
            BloodSupply result = ((OkObjectResult)bloodSupplyController.GetByType("A+"))?.Value as BloodSupply;

            result.Amount.ShouldBe(150);
        }

        [Fact]
        public void No_blood_in_database()
        {
            using var scope = Factory.Services.CreateScope();
            var bloodConsumptionRecordController = SetupBloodConsumptionRecordController(scope);
            var bloodSupplyController = SetupBloodSupplyController(scope);
            var bloodConsumptionRecord = new BloodConsumptionRecordRequestDto
            {
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Amount = new Amount(50.00),
                BloodType = "B+",
                Reason = "Reason 2"
            };

            BloodConsumptionRecord createdRecord = ((ObjectResult)bloodConsumptionRecordController.Create(bloodConsumptionRecord)).Value as BloodConsumptionRecord;

            createdRecord.ShouldBe(null);
        }
    }
}
