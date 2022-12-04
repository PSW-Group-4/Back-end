using IntegrationLibrary.Common;
using System;

namespace IntegrationAPI.Dtos.BloodTypes
{
    public class BloodTypeConverter
    {
        public static BloodTypeDto Convert(BloodType entity)
        {
            return new BloodTypeDto
            {
                BloodGroup = entity.BloodGroup.ToString(),
                RhFactor = entity.RhFactor.ToString()
            };
        }

        public static BloodType Convert(BloodTypeDto dto)
        {
            return new BloodType(
                        (BloodGroup)Enum.Parse(typeof(BloodGroup), dto.BloodGroup),
                        (RhFactor)Enum.Parse(typeof(RhFactor), dto.RhFactor)
                    );
        }
    }
}
