using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Repository;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using NotFoundException = IntegrationLibrary.Exceptions.NotFoundException;
using System.Net.Mail;
using System.Net;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Patients.Model;
using MimeKit;
using IntegrationLibrary.Utilities;
using HospitalLibrary.AcountActivation.Service;
using HospitalLibrary.AcountActivation.Model;

namespace HospitalLibrary.Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAcountActivationService _acountActivationService;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IAcountActivationService acountActivationService, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _acountActivationService = acountActivationService;
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

        public AcountActivationInfo RegisterPatient(User user, Guid patientId)
        {
            user.PersonId = patientId;
            user.Role = UserRole.Patient;
            user.IsAccountActive = false;
            user.IsBlocked = false;
            _userRepository.Create(user);

            //DODAO
            //user.VerificationToken = Guid.NewGuid();
            AcountActivationInfo info = new AcountActivationInfo();
            info.PersonId = patientId;
            info.ActivationToken = Guid.NewGuid();    
            return _acountActivationService.Create(info);
        }

        public string AuthenticatePublic(string username, string password)

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

        public string AuthenticatePrivate(string username, string password)
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

            if (user.Role == UserRole.Patient)
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
