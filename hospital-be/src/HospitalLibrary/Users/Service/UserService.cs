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
using System.Linq;

namespace HospitalLibrary.Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAcountActivationService _acountActivationService;
        private readonly IJwtService _jwtService;
        private readonly IPatientRepository _patientRepository;

        public UserService(IUserRepository userRepository, IAcountActivationService acountActivationService, IJwtService jwtService,
            IPatientRepository patientRepository)
        {
            _userRepository = userRepository;
            _acountActivationService = acountActivationService;
            _jwtService = jwtService;
            _patientRepository = patientRepository;
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

            _patientRepository.GetById(patientId);
            user.ConnectPersonToUser(patientId);
            _userRepository.Create(user);

            //DODAO
            AcountActivationInfo info = new AcountActivationInfo();
            info.PersonId = patientId;
            info.ActivationToken = Guid.NewGuid();    
            return _acountActivationService.Create(info);
        }

        public void ActivateAccount(Guid activationToken, Guid userId) 
        {

            var accountActivationInfo = _acountActivationService.GetAll().FirstOrDefault(r => r.PersonId == userId);
            if (accountActivationInfo == null)
            {
                throw new NotFoundException();
            }

            if (IsAlreadyActivated(accountActivationInfo))
            {
                throw new AcountAlreadyActivatedException();
            }

            if (TokensMatch(activationToken, accountActivationInfo))
            {
                var user = _userRepository.GetAll().FirstOrDefault(r => r.PersonId == userId);
                if (user == null) 
                { 
                    throw new NotFoundException(); 
                }

                user.ActivateAccount();
                _userRepository.Update(user);

                accountActivationInfo.ActivationToken = Guid.Empty;
                _acountActivationService.Update(accountActivationInfo);
            }
            else
            {
                throw new TokensDoNotMatchException();
            }
        }

        private bool IsAlreadyActivated(AcountActivationInfo info)
        {
            return info.ActivationToken == Guid.Empty;
        }

        private bool TokensMatch(Guid activationToken, AcountActivationInfo info)
        {
            return activationToken == info.ActivationToken;
        }

        public string AuthenticatePublic(string username, string password)

        {
            Password enteredPassword = new Password(password);
            User user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new NotFoundException();
            }
            
            if(!user.Password.Equals(enteredPassword))
            {
                throw new BadPasswordException();
            }

            if(!user.IsAccountActive)
            {
                throw new AccountNotActivatedException();
            }

            if (user.Role != UserRole.Patient)
            {
                throw new UnauthorizedException();
            }
            if (user.IsBlocked)
            {
                throw new UserIsBlockedException();
            }

            return _jwtService.GenerateToken(user);
        }

        public string AuthenticatePrivate(string username, string password)
        {
            Password enteredPassword = new Password(password);
            User user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new NotFoundException();
            }
            
            if(!user.Password.Equals(enteredPassword))
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

        public bool IsUsernameUnique(string username)
        {
          
            return _userRepository.IsUsernameUnique(username);
        }

        public void BlockUser(string username)
        {
            User user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new NotFoundException();
            }
            user.Block();
            _userRepository.Update(user);

        }

        public void UnblockUser(string username)
        {
            User user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new NotFoundException();
            }
            user.Unblock();
            _userRepository.Update(user);
        }

        public IEnumerable<User> GetAllSuspiciousUsers()
        {
            return GetAll().Where(u => u.IsUserSuspicious()).OrderBy(u=>u.Username);
        }

        public void AddSuspiciousActivityToUser(Guid personId,SuspiciousActivity suspiciousActivity)
        {
            User user = _userRepository.GetByPersonId(personId);
            user.AddSuspiciousActivity(suspiciousActivity);

            _userRepository.Update(user);
        }

       
    }
}
