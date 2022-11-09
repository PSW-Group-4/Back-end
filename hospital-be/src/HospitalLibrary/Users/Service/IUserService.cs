﻿using HospitalLibrary.Users.Model;
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
        public User RegisterPatient(User user, Guid patientId);

        public User Authenticate(string username, string password);
    }
}
