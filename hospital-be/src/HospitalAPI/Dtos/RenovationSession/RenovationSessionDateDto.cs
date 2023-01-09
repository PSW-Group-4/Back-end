using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos.RenovationSession
{
    public class RenovationSessionDateDto
    {
        public Guid AggregateId {get; set;}
        public DateTime Start {get; set;}
        public DateTime End {get; set;}
        
    }
}