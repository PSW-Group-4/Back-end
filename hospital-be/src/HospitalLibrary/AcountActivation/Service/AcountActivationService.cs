using HospitalLibrary.AcountActivation.Model;
using HospitalLibrary.AcountActivation.Repository;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using IntegrationLibrary.Utilities;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AcountActivation.Service
{
    public class AcountActivationService : IAcountActivationService
    {
        public readonly IAcountActivationRepository _acountActivationRepository;
        public readonly IPatientService _patientService;


        public AcountActivationService(IAcountActivationRepository acountActivationRepository, IPatientService patientService)
        {
            _acountActivationRepository = acountActivationRepository;
            _patientService = patientService;
        }

        public AcountActivationInfo Create(AcountActivationInfo info)
        {
            return _acountActivationRepository.Create(info);
        }

        public void Delete(Guid id)
        {
            _acountActivationRepository.Delete(id);
        }

        public IEnumerable<AcountActivationInfo> GetAll()
        {
            return _acountActivationRepository.GetAll();
        }

        public AcountActivationInfo GetById(Guid id)
        {
            return _acountActivationRepository.GetById(id);
        }

        public void SendVerificationLinkEmail(AcountActivationInfo info)
        {
            //Stavi tacan port
            var varifyUrl = "http://localhost:4200/loginPage?token=" + info.ActivationToken + "&id=" + info.PersonId;
            Patient patient = _patientService.GetById(info.PersonId);
            string recipientName = patient.Name + " " + patient.Surname;
            string recipientEmail = patient.Email.Address;
            string subject = "Account activation";
            string emailText = "Please click the following link to activate your account: " + varifyUrl;

            MimeMessage emailMessage = EmailSending.CreateTxtEmail(recipientName, recipientEmail, subject, emailText);
            EmailSending.SendEmail(emailMessage);
        }

        public AcountActivationInfo Update(AcountActivationInfo info)
        {
            return _acountActivationRepository.Update(info);
        }
    }
}
