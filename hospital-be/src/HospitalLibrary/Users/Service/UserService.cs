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

namespace HospitalLibrary.Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPatientService _patientService;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IPatientService patientService, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _patientService = patientService;
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

            //DODAO
            user.VerificationToken = Guid.NewGuid();

            return _userRepository.Create(user);
        }

        public void SendVerificationLinkEmail(User user)
        {
            /*var varifyUrl = "http://localhost:57197/loginPage?" + user.VerificationToken;
            var fromMail = new MailAddress("stefanapostolovic1@gmail.com", "welcome");
            var toMail = new MailAddress(_patientService.GetById(user.PersonId).Email);
            var frontEmailPassword = "abnHhE92@hse_-Mz";
            string subject = "Your account is successfully created";
            string body = "<br/><br/>We are excited to tell you that your account is" +
                        " successfully created. Please click on the below link to verify your account" +
                        " <br/><br/><a href='" + varifyUrl + "'>" + varifyUrl + "</a> ";

            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, frontEmailPassword)

            };
            using (var message = new MailMessage(fromMail, toMail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);*/;

            //TODO smisliti kako link da bude dinamican, a ne da zakucam port na kome trci localhost
            var varifyUrl = "http://localhost:4200/loginPage?token=" + user.VerificationToken + "&id=" + user.PersonId;
            Patient patient = _patientService.GetById(user.PersonId);
            String recipientName = patient.Name + " " + patient.Surname;
            String recipientEmail = "shadowhuntet@gmail.com";
            String subject = "Account activation";
            String emailText = "Please click the following link to activate your account: " + varifyUrl;

            MimeMessage emailMessage = EmailSending.createTxtEmail(recipientName, recipientEmail, subject, emailText);
            EmailSending.sendEmail(emailMessage);
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
