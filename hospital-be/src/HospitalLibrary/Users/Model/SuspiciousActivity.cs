﻿using HospitalLibrary.Exceptions;
using System;

namespace HospitalLibrary.Users.Model
{
    public class SuspiciousActivity
    {
        public string ActivityName { get; private set; }
        public DateTime ActivityTime { get; private set; }

        public SuspiciousActivity(string activityName, DateTime activityTime)
        {
            ActivityName = activityName;
            ActivityTime = activityTime;
            Validate();
        }

        private void Validate()
        {
            if (DateTime.Now < ActivityTime)
            {
                throw new ValueObjectValidationFailedException();
            }
            if (string.IsNullOrEmpty(ActivityName))
            {
                throw new ValueObjectValidationFailedException();
            }
        }



    }
}