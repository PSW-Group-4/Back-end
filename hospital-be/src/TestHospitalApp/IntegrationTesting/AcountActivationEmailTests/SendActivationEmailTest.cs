using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.Address;
using HospitalAPI.Dtos.User;
using HospitalLibrary.AcountActivation.Model;
using HospitalLibrary.AcountActivation.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Settings;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Common;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting.AcountActivationEmailTests
{
    public class SendActivationEmailTest : BaseIntegrationTest
    {
        public SendActivationEmailTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        public static UserController SetupUserController(IServiceScope scope, Mock<IAcountActivationService> mockSendEmail)
        {
            return new UserController(scope.ServiceProvider.GetRequiredService<IUserService>(),
                scope.ServiceProvider.GetRequiredService<IAddressService>(),
                scope.ServiceProvider.GetRequiredService<IPatientService>(),
                mockSendEmail.Object,
                scope.ServiceProvider.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IJwtService>()
                );
        }

        [Fact]
        public void SendActivationEmail()
        {
            var mockSendEmail = new Mock<IAcountActivationService>();
            using var scope = Factory.Services.CreateScope();
            var userController = SetupUserController(scope, mockSendEmail);
            var PatientRegistrationDto = SetupDtos();

            AcountActivationInfo activationInfo = 
                ((ObjectResult)userController.RegisterPatient(PatientRegistrationDto))?.Value as AcountActivationInfo;

            mockSendEmail.Verify(n => n.SendVerificationLinkEmail(activationInfo), Times.Once);
        }

        private PatientRegistrationDto SetupDtos()
        {
            UserLoginDto userDto = new UserLoginDto
            {
                Username = "username",
                Password = "password",
            };

            AddressRequestDto addressDto = new AddressRequestDto
            {
                City = "city",
                Country = "country",
                Street = "street",
                StreetNumber = "number"
            };

            PatientRegistrationDto patientDto = new PatientRegistrationDto
            {
                UserLoginDto = userDto,
                AddressRequestDto = addressDto,
                Name = "name",
                Surname = "surname",
                Birthdate = DateTime.Now,
                Gender = Gender.Male,
                Jmbg = new Jmbg("1807000730038"),
                Email = "testemail123@gmail.com",
                PhoneNumber = "123123123",
                BloodType = BloodType.FromString("A+"),
                AllergieIds = new List<Guid>(),
                ChoosenDoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e")
            };

            return patientDto;
        }
    }
}
