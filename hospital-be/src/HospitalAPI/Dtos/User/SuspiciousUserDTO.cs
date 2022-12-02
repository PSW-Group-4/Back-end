using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos.User
{
    public class SuspiciousUserDTO
    {
        public string Username { get; set; }
        public bool IsBlocked { get; set; }
        public int NumberOfRecentSuspiciousActivities { get;set;}


        public SuspiciousUserDTO(string username, bool isBlocked, int numberOfRecentSuspiciousActivities)
        {
            Username = username;
            IsBlocked = isBlocked;
            NumberOfRecentSuspiciousActivities = numberOfRecentSuspiciousActivities;
        }
    }
}
