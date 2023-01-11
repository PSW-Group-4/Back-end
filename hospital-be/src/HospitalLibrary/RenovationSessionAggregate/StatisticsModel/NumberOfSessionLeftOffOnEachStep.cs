using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RenovationSessionAggregate.StatisticsModel
{
    public class NumberOfSessionLeftOffOnEachStep
    {
        public int NumberOnType {get; set;}
        public int NumberOnOldRooms {get; set;}
        public int NumberOnTimeframe {get; set;}
        public int NumberOnNewRooms {get; set;}
        public int NumberOnSpecificTime {get; set;}

        public NumberOfSessionLeftOffOnEachStep() {
            this.NumberOnNewRooms = 0;
            this.NumberOnOldRooms = 0;
            this.NumberOnSpecificTime = 0;
            this.NumberOnTimeframe = 0;
            this.NumberOnType = 0;
        }
    }
}