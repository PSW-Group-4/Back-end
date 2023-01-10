using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RenovationSessionAggregate.StatisticsModel
{
    public class FinishedAndUnfinishedSessionStatistic
    {
        public int NumberOfFinished {get; private set;}
        public int NumberOfUnfinished {get; private set;}

        public FinishedAndUnfinishedSessionStatistic(int finished, int unfinished ) {
            this.NumberOfFinished = finished;
            this.NumberOfUnfinished = unfinished;
        }
        
    }
}