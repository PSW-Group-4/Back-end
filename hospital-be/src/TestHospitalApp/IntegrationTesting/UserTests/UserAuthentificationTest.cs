using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.User;
using HospitalLibrary.AcountActivation.Service;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Users.Service;
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

namespace TestHospitalApp.IntegrationTesting.UserTests
{
    public class UserAuthentificationTest : BaseIntegrationTest
    {
        public UserAuthentificationTest(TestDatabaseFactory<Startup> factory) : base(factory){ }

        private static UserController SetupUserController(IServiceScope scope)
        {
            return new UserController(scope.ServiceProvider.GetRequiredService<IUserService>(),
                scope.ServiceProvider.GetRequiredService<IAddressService>(),
                scope.ServiceProvider.GetRequiredService<IPatientService>(),
                scope.ServiceProvider.GetRequiredService<IAcountActivationService>(),
                scope.ServiceProvider.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IJwtService>());
        }

        [Fact]
        public void User_enters_wrong_username_and_password()
        {
            using var scope = Factory.Services.CreateScope();
            var userController = SetupUserController(scope);

            UserLoginDto userDto = new UserLoginDto { Username = "wrongUsername", Password = "wrongPass123" };

            var response = userController.LoginPublic(userDto);
            response.ShouldBeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void User_enters_wrong_password_and_valid_username()
        {
            using var scope = Factory.Services.CreateScope();
            var userController = SetupUserController(scope);

            UserLoginDto userDto = new UserLoginDto { Username = "user", Password = "wrongPass" };

            var response = (ObjectResult)userController.LoginPublic(userDto);
            response.Value.ShouldBe("Bad password");
        }

        [Fact]
        public void User_account_is_not_activated()
        {
            using var scope = Factory.Services.CreateScope();
            var userController = SetupUserController(scope);

            UserLoginDto userDto = new UserLoginDto { Username = "notactive", Password = "notactive123" };

            var response = (StatusCodeResult)userController.LoginPublic(userDto);
            response.StatusCode.ShouldBe(403);
        }

        [Fact]
        public void User_enters_valid_username_and_password()
        {
            using var scope = Factory.Services.CreateScope();
            var userController = SetupUserController(scope);

            UserLoginDto userDto = new UserLoginDto { Username = "user", Password = "pass123" };

            var response = userController.LoginPublic(userDto);
            response.ShouldBeOfType<OkObjectResult>();
        }

    }
}
