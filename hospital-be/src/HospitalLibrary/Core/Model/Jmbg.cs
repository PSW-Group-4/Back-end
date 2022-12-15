using HospitalLibrary.Exceptions;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Jmbg
    {
        public string JmbgValue { get; private set; }
        public Jmbg(){}

        public Jmbg(string jmbgValue)
        {
            JmbgValue = jmbgValue;
            Validate(jmbgValue);
        }

        private void Validate(string jmbgValue)
        {
            if (!IsDigit(jmbgValue)) 
            {
                throw new ValueObjectValidationFailedException();
            }

            if (!IsCorrectLength(jmbgValue))
            {
                throw new ValueObjectValidationFailedException();
            }

            if (!IsChecksumValid(jmbgValue))
            {
                throw new ValueObjectValidationFailedException();
            }
                
        }

        private bool IsDigit(string jmbgValue)
        {
            return jmbgValue.All(char.IsDigit);
        }

        private bool IsCorrectLength(string jmbg)
        {
            return jmbg.Length == 13;
        }

        private bool IsChecksumValid(string jmbg)
        {
            List<int> jmbgNumericValues = GetNumericValues(jmbg);
            int checksum = CalculateChecksum(jmbgNumericValues);

            return checksum == jmbgNumericValues[12];
        }

        private List<int> GetNumericValues(string sequence)
        {
            List<int> returnValue = new List<int>();

            for (int i = 0; i < sequence.Length; i++) 
            {
                returnValue.Add((int)char.GetNumericValue(sequence[i]));
            }

            return returnValue;
        }

        private int CalculateChecksum(List<int> jmbgNumericValues)
        {
            return 11 - ((7 * (jmbgNumericValues[0] + jmbgNumericValues[6]) + 6 *
                (jmbgNumericValues[1] + jmbgNumericValues[7]) +
                5 * (jmbgNumericValues[2] + jmbgNumericValues[8]) +
                4 * (jmbgNumericValues[3] + jmbgNumericValues[9]) +
                3 * (jmbgNumericValues[4] + jmbgNumericValues[10]) +
                2 * (jmbgNumericValues[5] + jmbgNumericValues[11])) % 11);
        }

        public override bool Equals(object obj)
        {
            return obj is Jmbg jmbg &&
                   JmbgValue == jmbg.JmbgValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(JmbgValue);
        }
    }
}
