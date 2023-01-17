using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.Admissions.Model
{
    public class Reason
    {
        public string Text { get;  }
        private const string TextRegex = @"^[A-Z]+[a-zA-Z ]*$";

        public Reason(string text)
        {
            Text = text;
           // if (!IsValid())
            //{
            //    throw new ValueObjectValidationFailedException("Reason is not in proper format");
            //}
        }        

        private bool IsValid()
        {
            if (String.IsNullOrEmpty(Text))
            {
                return false;
            }

            var match = Regex.Match(Text, TextRegex);
            return match.Success;
        }
        protected bool Equals(Reason other)
        {
            return Text == other.Text;
        }

        public bool checkText(string text)
        {
            if (Text.Contains(text))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Reason)obj);
        }
        public override int GetHashCode()
        {
            return (Text != null ? Text.GetHashCode() : 0);
        }

    }
}
