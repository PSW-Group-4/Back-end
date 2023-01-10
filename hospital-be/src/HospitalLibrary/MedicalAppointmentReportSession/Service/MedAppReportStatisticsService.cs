using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.MedicalAppointmentReportSession.Repository;
using HospitalLibrary.Patients.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Service
{
    public class MedAppReportStatisticsService : IMedAppReportStatisticsService
    {

        private readonly IMedicalAppointmentReportSessionRepository _medAppSessionRepository;
        private readonly IAgeGroupRepository _ageGroupRepository;

        public MedAppReportStatisticsService(IMedicalAppointmentReportSessionRepository medAppSessionRepository, IAgeGroupRepository ageGroupRepository)
        {
            _medAppSessionRepository = medAppSessionRepository;
            _ageGroupRepository = ageGroupRepository;
        }

        public IDictionary<string, double> GetDoctorTimeSteps()
        {
            return null;
        }

        public IDictionary<SelectionReport, int> GetNumberEachStep()
        {
            IEnumerable<MedicalAppointmentReportSession> sessions = _medAppSessionRepository.GetAll();

            IDictionary<SelectionReport, int> timesPerSelection = new Dictionary<SelectionReport, int>();
            foreach (SelectionReport selection in Enum.GetValues(typeof(SelectionReport)))
            {
                timesPerSelection.Add(selection, 0);
            }

            if (!sessions.Any()) return timesPerSelection;

            foreach (MedicalAppointmentReportSession session in sessions)
            {
                timesPerSelection[SelectionReport.Symptom] += CountTimesAtSymptomSelection(session);
                timesPerSelection[SelectionReport.ReportText] += CountTimesAtReportTextSelection(session);
                timesPerSelection[SelectionReport.Medicine] += CountTimesAtMedicineSelection(session);
                timesPerSelection[SelectionReport.Review] += CountTimesAtReviewSelection(session);
            }

            foreach (var count in timesPerSelection)
            {
                timesPerSelection[count.Key] = count.Value / sessions.Count();
            }

            return timesPerSelection;
        }

        public IDictionary<string, int> GetNumberSteps()
        {
            return null;
        }

        public IDictionary<SelectionReport, double> GetTimeEachStep()
        {
            return null;
        }

        public IDictionary<string, double> GetTimeSteps()
        {
            return null;
        }


        private int CountTimesAtSymptomSelection(MedicalAppointmentReportSession session)
        {

            int timesAtDateSelection = session.Events
                .OfType<StartedScheduling>().Count();

            timesAtDateSelection += session.Events
                .OfType<GoneBackToSelection>().Count(e => e.Selection == SelectionReport.Symptom);

            return timesAtDateSelection;
        }

        private int CountTimesAtReportTextSelection(MedicalAppointmentReportSession session)
        {

            int timesAtSpecialitySelection = session.Events
                .OfType<ChosenSymptom>().Count();

            timesAtSpecialitySelection += session.Events
                .OfType<GoneBackToSelection>().Count(e => e.Selection == SelectionReport.ReportText);

            return timesAtSpecialitySelection;
        }

        private int CountTimesAtMedicineSelection(MedicalAppointmentReportSession session)
        {

            int timesAtDoctorSelection = session.Events
                .OfType<ChosenReportText>().Count();

            timesAtDoctorSelection += session.Events
                .OfType<GoneBackToSelection>().Count(e => e.Selection == SelectionReport.Medicine);

            return timesAtDoctorSelection;
        }

        private int CountTimesAtReviewSelection(MedicalAppointmentReportSession session)
        {

            int timesAtTimeSelection = session.Events
                .OfType<ChosenMedicine>().Count();

            timesAtTimeSelection += session.Events
                .OfType<GoneBackToSelection>().Count(e => e.Selection == SelectionReport.Review);

            return timesAtTimeSelection;
        }
    }
}
