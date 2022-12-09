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
        public string jmbg { get; private set; }

        public Jmbg(string jmbg)
        {
            Validate(jmbg);
        }

        private void Validate(string jmbg)
        {
            if (!IsDigit(jmbg)) 
            {
                throw new ValueObjectValidationFailedException();
            }

            if (!IsCorrectLength(jmbg))
            {
                throw new ValueObjectValidationFailedException();
            }

            if (!IsChecksumValid(jmbg))
            {
                throw new ValueObjectValidationFailedException();
            }
                
        }

        private bool IsDigit(string jmbg)
        {
            return jmbg.All(char.IsDigit);
        }

        private bool IsCorrectLength(string jmbg)
        {
            return jmbg.Length == 13;
        }

        private bool IsChecksumValid(string jmbg)
        {
            List<int> jmbgNumericValues = GetNumericValues(jmbg);
            int checksum =
                11 - ((7 * (jmbgNumericValues[0] + jmbgNumericValues[6]) + 6 *
                (jmbgNumericValues[1] + jmbgNumericValues[7]) +
                5 * (jmbgNumericValues[2] + jmbgNumericValues[8]) +
                4 * (jmbgNumericValues[3] + jmbgNumericValues[9]) +
                3 * (jmbgNumericValues[4] + jmbgNumericValues[10]) +
                2 * (jmbgNumericValues[5] + jmbgNumericValues[11])) % 11);

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
    }
}
