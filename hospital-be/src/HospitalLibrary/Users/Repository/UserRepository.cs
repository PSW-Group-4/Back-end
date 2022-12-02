using HospitalLibrary.Core.Repository;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HospitalDbContext _context;

        public UserRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByUsername(string username)
        {
            var result =  _context.Users.Find(username);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return  result;
        }

        public bool IsUsernameUnique(string username)
        {
            var result = _context.Users.Find(username);
            return result == null;
        }


        public User Create(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
            return User;
        }

        public User Update(User user)
        {
            var updatingUser = _context.Users.SingleOrDefault(p => p.Username == user.Username);
            if (updatingUser == null)
            {
                throw new NotFoundException();
            }
            
            updatingUser.Update(user);
            
            _context.SaveChanges();
            return updatingUser;
        }

        public void Delete(string username)
        {
            var User = GetByUsername(username);
            _context.Users.Remove(User);
            _context.SaveChanges();
        }

        public User GetByPersonId(Guid personId)
        {
            var user = _context.Users.SingleOrDefault(u => u.PersonId == personId);
            if (user == null)
            {
                throw new NotFoundException();
            }

            return user;
        }
    }
}
