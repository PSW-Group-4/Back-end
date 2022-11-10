using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;
using NotFoundException = IntegrationLibrary.Exceptions.NotFoundException;

namespace HospitalLibrary.Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        public User Authenticate(string username, string password)
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
            
            return user;
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
