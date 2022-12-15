using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;

namespace HospitalLibrary.Users.Model
{
    public enum UserRole
    {
        Patient,
        Doctor,
        Manager,
        Clerk
    }
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Username { get;private set; }

        [Column(TypeName = "jsonb")]
        public Password Password { get; private set; }
        public bool IsAccountActive { get; private set; }
        public bool IsBlocked { get; private set; }
        public UserRole Role { get; private set; }
        //In managers case it can be null
        public Guid? PersonId { get; private set; }


        public User(string username, Password password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
            IsAccountActive = false;
            IsBlocked = false;
            Validate();
        }

        public void ActivateAccount()
        {
            IsAccountActive = true;
        }

        public void ConnectPersonToUser(Guid? personId)
        {
            PersonId = personId;
        }

        private void Validate()
        {
            if (Password==null)
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Username))
                throw new EntityObjectValidationFailedException();
           

        }

        [Column(TypeName = "jsonb")] private List<SuspiciousActivity> suspicious_activities;

        public List<SuspiciousActivity> SuspiciousActivities
        {
            get
            {
                suspicious_activities ??= new List<SuspiciousActivity>();
                return new List<SuspiciousActivity>(suspicious_activities);
            }
            set{}

        }

        public void AddSuspiciousActivity(SuspiciousActivity suspiciousActivity)
        {
            suspicious_activities ??= new List<SuspiciousActivity>();
            suspicious_activities.Add(suspiciousActivity);
        }


        public bool HasEnoughSuspiciousActivities()
        {

            return Constants.Constants.MinSuspiciousActivityCount <= NumberOfSuspiciousActivitiesInRecentPeriod();
        }

        public int NumberOfSuspiciousActivitiesInRecentPeriod()
        {
            return SuspiciousActivities.Count(suspiciousActivity => suspiciousActivity.ActivityTime >= DateTime.Now.AddDays(-Constants.Constants.SuspiciousActivityPeriodDaysCheck));
        
        }

        public void Block()
        {
            if (IsBlocked)
            {
                throw new UserIsAlreadyBlockedException();
            }

            if (!HasEnoughSuspiciousActivities())
            {
                throw new UserCanNotBeBlocked();
            }

            IsBlocked = true;
        }

        public void Unblock()
        {
            if (!IsBlocked)
            {
                throw new UserIsNotBlockedException();
            }
            IsBlocked = false;
        }

        public bool IsUserSuspicious()
        {
            return IsBlocked || HasEnoughSuspiciousActivities();
        }

        internal void Update(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Role = user.Role;
            PersonId = user.PersonId;
            suspicious_activities = user.SuspiciousActivities;
        }


    
    }
}
