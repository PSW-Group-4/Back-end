using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RenovationSessionAggregate.StatisticsModel
{
    public class FinishedSessionStatisticsForTable
    {
        public DateTime StartTime {get; private set;}
        public double TotalTime {get; private set;}
        public int TimesGoneBack {get; private set;}

        public AverageTimeSpentOnStepsInSession AverageTime {get; private set;}

        public FinishedSessionStatisticsForTable(DateTime dateTime, double totalTime, int timeGoneBack, AverageTimeSpentOnStepsInSession averageTimeSpentOnStepsInSession) {
            this.StartTime = dateTime;
            this.TotalTime = totalTime;
            this.TimesGoneBack = timeGoneBack;
            this.AverageTime = averageTimeSpentOnStepsInSession;
        }
    }
}