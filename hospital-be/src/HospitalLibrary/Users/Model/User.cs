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
        public string Username { get; set; }

        [Column(TypeName = "jsonb")]
        public Password Password { get; set; }
        public bool IsAccountActive { get; set; }
        public bool IsBlocked { get; set; }
        public UserRole Role { get; set; }
        //In managers case it can be null
        public Guid? PersonId { get; set; }

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
