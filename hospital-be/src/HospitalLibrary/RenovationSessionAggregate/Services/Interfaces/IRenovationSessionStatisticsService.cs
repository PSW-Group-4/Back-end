using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.StatisticsModel;

namespace HospitalLibrary.RenovationSessionAggregate.Services.Interfaces
{
    public interface IRenovationSessionStatisticsService
    {
        public FinishedAndUnfinishedSessionStatistic GetFinishedAndUnfinishedSessionStatistic();
        public IEnumerable<FinishedSessionStatisticsForTable> GetFinishedSessionStatisticsForTable();
        public AverageTimeSpentOnStepsInSession GetAverageTimeSpentOnStepsInSession();
    }
}