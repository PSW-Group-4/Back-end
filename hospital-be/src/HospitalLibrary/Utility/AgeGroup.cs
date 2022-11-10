namespace HospitalLibrary.Utility
{
    public class AgeGroup
    {
        public string GropuName { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public AgeGroup(string gropuName, int minAge, int maxAge)
        {
            GropuName = gropuName;
            MinAge = minAge;
            MaxAge = maxAge;
        }
    }
}
