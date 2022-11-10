using HospitalLibrary.Utility;
using System.Collections.Generic;

namespace HospitalLibrary.Constants
{
    public static class AgeGroupsConstants
    {

        public static readonly List<AgeGroup> AgeGroups = new()
        {
            new AgeGroup("Child", 0, 16),
            new AgeGroup("Young adults", 17, 30),
            new AgeGroup("Middle-aged adults", 31, 51),
            new AgeGroup("Old Adults", 51, 999),
        };

    }
}
