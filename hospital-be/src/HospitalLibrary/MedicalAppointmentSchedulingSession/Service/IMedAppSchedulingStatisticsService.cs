using System.Collections.Generic;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Service
{
    public interface IMedAppSchedulingStatisticsService
    {
        public IDictionary<Selection, int> GetTimesPerSelection();
        public IDictionary<Selection, double> GetSpentTimePerSelection();
        public IDictionary<string, double> GetTotalSpentTimePerAgeGroup();
        public IDictionary<string, int> GetTotalStepsPerAgeGroup();
        public IDictionary<string, double> GetSchedulingSuccessRatePerAgeGroup();
        public IDictionary<string, int> GetNumberOfChoosesPerDoctor();
    }
}