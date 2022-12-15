using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.AppointmentReport.Service;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.MedicalReport.Services;
using HospitalLibrary.Reports.Service;
using HospitalLibrary.RoomsAndEqipment.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting
{
    public class GetAvailableAppointmentsInDateRange : BaseIntegrationTest
    {
        public GetAvailableAppointmentsInDateRange(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static DoctorAppointmentController SetupReportController(IServiceScope scope)
        {
            return new DoctorAppointmentController(scope.ServiceProvider.GetRequiredService<IDoctorAppointmentService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        

        [Fact]

        public void getFreeTermins()
        {
            using var scope = Factory.Services.CreateScope();
            var doctorAppointmentController= SetupReportController(scope);            

            DateTime timeStart = new DateTime(2022, 12, 15, 0, 0, 0);
            DateTime timeEnd = new DateTime(2022, 12, 17, 0, 0, 0);

            Guid patientId = new Guid("1d9aae17-fc67-4a7c-b05e-815fb94c4639");
            Guid doctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e");
            
            List<DateRange> res = ((OkObjectResult)doctorAppointmentController.getAvailableTerminsForAnotherDoctor(timeStart.ToString(), timeEnd.ToString(), patientId, doctorId))?.Value as List<DateRange>;
            res.ShouldNotBeNull();
            
        }
    }
}
