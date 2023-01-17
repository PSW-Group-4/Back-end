using IntegrationAPI.Dtos.BloodTypes;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;

namespace IntegrationAPI.Dtos.BloodProducts
{
    public class BloodConverter
    {
        public static Blood Convert(BloodDto bloodDto)
        {
            return new Blood(BloodTypeConverter.Convert(bloodDto.BloodType), bloodDto.Amount);
        }

        public static BloodDto Convert(Blood blood)
        {
            return new BloodDto(BloodTypeConverter.Convert(blood.BloodType), blood.Amount);
        }

        public static List<BloodDto> Convert(List<Blood> blood)
        {
            var retVal = new List<BloodDto>();
            foreach (var bloodItem in blood)
            {
                retVal.Add(Convert(bloodItem));
            }
            return retVal;
        }

        internal static List<Blood> Convert(List<BloodDto> bloodDto)
        {
            if (bloodDto == null)
            {
                return new List<Blood>();
            }
            var retVal = new List<Blood>();
            foreach (var bloodItem in bloodDto)
            {
                retVal.Add(Convert(bloodItem));
            }
            return retVal;
        }
    }
}
