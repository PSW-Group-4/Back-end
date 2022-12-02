using HospitalLibrary.AcountActivation.Model;
using HospitalLibrary.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Users.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User GetByUsername(string username);
        User Create(User user);
        User Update(User user);
        void Delete(string username);
        public AcountActivationInfo RegisterPatient(User user, Guid patientId);
        public string AuthenticatePublic(string username, string password);
        string AuthenticatePrivate(string userLoginUsername, string userLoginPassword);
        void ActivateAccount(Guid activationToken, Guid userId);
        bool IsUsernameUnique(string username);
        void BlockUser(string username);
        void UnblockUser(string username);
        IEnumerable<User> GetAllSuspiciousUsers();
        public void AddSuspiciousActivityToUser(Guid personId, SuspiciousActivity suspiciousActivity);

    }
}
