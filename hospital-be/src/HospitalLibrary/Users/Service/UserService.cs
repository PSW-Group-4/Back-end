using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Repository;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using NotFoundException = IntegrationLibrary.Exceptions.NotFoundException;

namespace HospitalLibrary.Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User RegisterPatient(User user, Guid patientId)
        {
            user.PersonId = patientId;
            user.Role = UserRole.Patient;
            user.IsAccountActive = false;
            user.IsBlocked = false;

            return _userRepository.Create(user);
        }

        public string AuthenticatePatient(string username, string password)
        {
            User user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new NotFoundException();
            }
            
            if(user.Password != password)
            {
                throw new BadPasswordException();
            }

            if (user.Role != UserRole.Patient)
            {
                throw new UnauthorizedException();
            }
            
            return _jwtService.GenerateToken(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public void Delete(string username)
        {
            _userRepository.Delete(username);
        }
    }
}
