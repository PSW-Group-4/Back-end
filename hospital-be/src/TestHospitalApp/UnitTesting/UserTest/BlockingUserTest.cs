using HospitalLibrary.Exceptions;
using HospitalLibrary.Users.Model;
using Shouldly;
using System;
using HospitalLibrary.Patients.Model;
using Xunit;

namespace TestHospitalApp.UnitTesting.UserTest
{
    public class BlockingUserTest
    {
        [Fact]
        public void Unblocking_blocked_user()
        {
           
            User user = new User("da", new Password("hahahaha"), UserRole.Patient);
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.Block();
            user.Unblock();
            user.IsBlocked.ShouldBe(false);
        }

        [Fact]
        public void Unblocking_unblocked_user()
        {
            User user = new User("da", new Password("hahahaha"), UserRole.Patient);
            Should.Throw<UserIsNotBlockedException>(() => user.Unblock());
        }

        [Fact]
        public void Blocking_unblocked_user_with_more_than_enough_suspicious_activities()
        {

            User user = new User("da", new Password("hahahaha"), UserRole.Patient);
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);

            user.Block();

            user.IsBlocked.ShouldBe(true);

        }
        [Fact]
        public void Blocking_unblocked_user_with_suspicious_activities_limit_case()
        {

            User user = new User("da", new Password("hahahaha"), UserRole.Patient);
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);

            user.Block();

            user.IsBlocked.ShouldBe(true);

        }

        [Fact]
        public void Blocking_unblocked_user_with_less_than_enough_suspicious_activities()
        {

            User user = new User("da", new Password("hahahaha"), UserRole.Patient);
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            Should.Throw<UserCanNotBeBlocked>(() => user.Block());

        }

        [Fact]
        public void Blocking_blocked_patient()
        {
            User user = new User("da", new Password("hahahaha"), UserRole.Patient);
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST");
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.AddSuspiciousActivity(suspiciousActivity);
            user.Block();

            Should.Throw<UserIsAlreadyBlockedException>(() => user.Block());


        }


    }
}
