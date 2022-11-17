using System;

namespace HospitalLibrary.Patients.Model
{
    public class AgeGroup
    {

        public Guid Id { get; set; }
        public string GropuName { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public AgeGroup(string gropuName, int minAge, int maxAge)
        {
            GropuName = gropuName;
            MinAge = minAge;
            MaxAge = maxAge;
        }

        public void Update(AgeGroup ageGroup)
        {
            GropuName = ageGroup.GropuName;
            MinAge = ageGroup.MinAge;
            MaxAge = ageGroup.MaxAge;
        }
    }
}
