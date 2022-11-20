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
            //TODO smisliti kako link da bude dinamican, a ne da zakucam port na kome trci localhost
            var varifyUrl = "http://localhost:4200/loginPage?token=" + info.ActivationToken + "&id=" + info.PersonId;
            Patient patient = _patientService.GetById(info.PersonId);
            String recipientName = patient.Name + " " + patient.Surname;
            String recipientEmail = "shadowhuntet@gmail.com";
            String subject = "Account activation";
            String emailText = "Please click the following link to activate your account: " + varifyUrl;

            MimeMessage emailMessage = EmailSending.createTxtEmail(recipientName, recipientEmail, subject, emailText);
            EmailSending.sendEmail(emailMessage);
        }

        public AcountActivationInfo Update(AcountActivationInfo info)
        {
            return _acountActivationRepository.Update(info);
        }
    }
}
