using HospitalLibrary.Core.Repository;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Users.Repository
{
    public interface IUserRepository {
        public User GetByUsername(string username);
        public void Delete(string username);
        public User Create(User User);
        public User Update(User user);
        public IEnumerable<User> GetAll();
        bool IsUsernameUnique(string username);
        User GetByPersonId(Guid personId);
    }
}
