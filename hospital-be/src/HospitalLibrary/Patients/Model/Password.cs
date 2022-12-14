using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.Patients.Model
{
    public class Password
    {
        public string PasswordValue { get; private set; }

        public Password(string passwordValue)
        {
            PasswordValue = passwordValue;
            Validate(passwordValue);
        }

        private void Validate(string passwordValue)
        {
            if(!IsInGoodFormat(passwordValue))
            {
                throw new ValueObjectValidationFailedException();
            }
        }

        private bool IsInGoodFormat(string passwordValue)
        {
            if (String.IsNullOrEmpty(passwordValue))
            {
                return false;
            }

            string regex = @"^.{4,20}$";
            var match = Regex.Match(passwordValue, regex);
            return match.Success;
        }

        public override bool Equals(object obj)
        {
            return obj is Password pass &&
                   PasswordValue == pass.PasswordValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PasswordValue);
        }
    }
}
