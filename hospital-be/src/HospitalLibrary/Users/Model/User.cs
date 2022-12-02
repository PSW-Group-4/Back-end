using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HospitalLibrary.Exceptions;

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
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAccountActive { get; set; }
        public bool IsBlocked { get; set; }
        public UserRole Role { get; set; }
        //In managers case it can be null
        public Guid? PersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("_suspiciousActivities")]
        private List<SuspiciousActivity> _suspiciousActivities;

        public List<SuspiciousActivity> SuspiciousActivities
        {
            get
            {
                _suspiciousActivities ??= new List<SuspiciousActivity>();
                return new List<SuspiciousActivity>(_suspiciousActivities);
            }

        }

        public void AddSuspiciousActivity(SuspiciousActivity suspiciousActivity)
        {
            _suspiciousActivities ??= new List<SuspiciousActivity>();
            _suspiciousActivities.Add(suspiciousActivity);
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
            _suspiciousActivities = user._suspiciousActivities;
        }


    }
}
