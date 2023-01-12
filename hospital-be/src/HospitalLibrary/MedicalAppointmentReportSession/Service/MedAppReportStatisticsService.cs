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


        public IDictionary<string, int> GetReportTable()
        {
            IEnumerable<MedicalAppointmentReportSession> sessions = _medAppSessionRepository.GetAll();
            IDictionary<string, int> timesPerSelection = new Dictionary<string, int>();

            List<string> steps = new List<string>()
            {
                "averageSteps","averageTime","averageSymptom","averageReportLenght", "averageMedicine"
            };
            foreach (string selection in steps)
            {
                timesPerSelection.Add(selection, 0);
            }

            if (!sessions.Any()) return timesPerSelection;


            foreach (MedicalAppointmentReportSession session in sessions)
            {
                int count = session.Events.Count();
                timesPerSelection["averageSteps"] += count;
                timesPerSelection["averageTime"] += Convert.ToInt32(GetSpentTimeOnSesion(session));
                if (session.SelectedNumberOfSymptoms.HasValue)
                {
                    timesPerSelection["averageSymptom"] += session.SelectedNumberOfSymptoms.Value;
                }
                if (session.SelectedReportText != null)
                {
                    timesPerSelection["averageReportLenght"] += session.SelectedReportText.Length;
                }
                if (session.SelectedNumberOfMedicines.HasValue)
                {
                    timesPerSelection["averageMedicine"] += session.SelectedNumberOfMedicines.Value;
                }

            }

            foreach (var count in timesPerSelection)
            {
                timesPerSelection[count.Key] = count.Value / sessions.Count();
            }

            return timesPerSelection;
        }


        public IDictionary<string, int> GetNumberSteps()
        {
            IEnumerable<MedicalAppointmentReportSession> sessions = _medAppSessionRepository.GetAll();
            IDictionary<string, int> timesPerSelection = new Dictionary<string, int>();

            List<string> steps = new List<string>()
            {
              // <<4      4 - 8         8 - 12     12>>
                "Small","SmallNormal","BigNormal","Big"
            };
            foreach (string selection in steps)
            {
                timesPerSelection.Add(selection, 0);
            }

            if (!sessions.Any()) return timesPerSelection;


            foreach (MedicalAppointmentReportSession session in sessions)
            {
                int count = session.Events.Count();
                if (count < 4)
                {
                    timesPerSelection["Small"] += count;
                }
                else if (count >= 4 && count < 8 )
                {
                    timesPerSelection["SmallNormal"] += count;
                }
                else if (count >= 8 && count < 12)
                {
                    timesPerSelection["BigNormal"] += count;
                }
                else
                {
                    timesPerSelection["Big"] += count;
                }
            }

            foreach (var count in timesPerSelection)
            {
                timesPerSelection[count.Key] = count.Value / sessions.Count();
            }

            return timesPerSelection;
        }

        public IDictionary<string, double> GetTimeSteps()
        {
            IEnumerable<MedicalAppointmentReportSession> sessions = _medAppSessionRepository.GetAll();
            IDictionary<string, double> timesPerSelection = new Dictionary<string, double>();

            List<string> steps = new List<string>()
            {
              // <<15      15 - 30         30 - 60     60>>
                "Small","SmallNormal","BigNormal","Big"
            };
            foreach (string selection in steps)
            {
                timesPerSelection.Add(selection, 0);
            }

            if (!sessions.Any()) return timesPerSelection;


            foreach (MedicalAppointmentReportSession session in sessions)
            {
                double count = GetSpentTimeOnSesion(session);
                if (count < 15)
                {
                    timesPerSelection["Small"] += count;
                }
                else if (count >= 15 && count < 30)
                {
                    timesPerSelection["SmallNormal"] += count;
                }
                else if (count >= 30 && count < 60)
                {
                    timesPerSelection["BigNormal"] += count;
                }
                else
                {
                    timesPerSelection["Big"] += count;
                }
            }

            foreach (var count in timesPerSelection)
            {
                timesPerSelection[count.Key] = count.Value / sessions.Count();
            }

            return timesPerSelection;
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

        public IDictionary<SelectionReport, double> GetTimeEachStep()
        {
            IEnumerable<MedicalAppointmentReportSession> sessions = _medAppSessionRepository.GetAll();

            IDictionary<SelectionReport, double> timesPerSelection = new Dictionary<SelectionReport, double>();
            foreach (SelectionReport selection in Enum.GetValues(typeof(SelectionReport)))
            {
                timesPerSelection.Add(selection, 0);
            }

            if (!sessions.Any()) return timesPerSelection;

            foreach (MedicalAppointmentReportSession session in sessions)
            {
                timesPerSelection[SelectionReport.Symptom] += GetSpentTime(session, typeof(StartedScheduling));
                timesPerSelection[SelectionReport.Symptom] += GetSpentTime(session, typeof(GoneBackToSelection));
                timesPerSelection[SelectionReport.ReportText] += GetSpentTime(session, typeof(ChosenSymptom));
                timesPerSelection[SelectionReport.Medicine] += GetSpentTime(session, typeof(ChosenReportText));
                timesPerSelection[SelectionReport.Review] += GetSpentTime(session, typeof(ChosenMedicine));
            }

            foreach (var count in timesPerSelection)
            {
                timesPerSelection[count.Key] = count.Value / sessions.Count();
            }

            return timesPerSelection;
        }

        public IDictionary<string, double> GetDoctorTimeSteps()
        {
            IEnumerable<MedicalAppointmentReportSession> sessions = _medAppSessionRepository.GetAll();
            IDictionary<string, double> timesPerSelection = new Dictionary<string, double>();

            List<string> steps = new List<string>()
            {
              // <<4      4 - 8         8 - 12     12>>
                "Small","SmallNormal","BigNormal","Big"
            };
            List<int> yearSteps = new List<int>()
            {
              25,45,60
            };
            foreach (string selection in steps)
            {
                timesPerSelection.Add(selection, 0);
            }

            if (!sessions.Any()) return timesPerSelection;


            foreach (MedicalAppointmentReportSession session in sessions)
            {
                int years = 0;
                if (session.Doctor != null)
                    years = DateTime.Now.Year - session.Doctor.Birthdate.Year;

                double count = GetSpentTimeOnSesion(session);
                if (years < yearSteps[0])
                {
                    timesPerSelection["Small"] += count;
                }
                else if (years >= yearSteps[0] && years < yearSteps[1])
                {
                    timesPerSelection["SmallNormal"] += count;
                }
                else if (years >= yearSteps[1] && years < yearSteps[2])
                {
                    timesPerSelection["BigNormal"] += count;
                }
                else
                {
                    timesPerSelection["Big"] += count;
                }
            }

            foreach (var count in timesPerSelection)
            {
                timesPerSelection[count.Key] = count.Value / sessions.Count();
            }

            return timesPerSelection;
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

        //Time is measured in seconds
        private double GetSpentTime(MedicalAppointmentReportSession session, Type eventType)
        {
            double timeSpent = 0;

            for (int i = 0; i < session.Events.Count(); i++)
            {
                //Base type is accesed because EF sometimes returns proxy of an object
                var baseType = session.Events[i].GetType().BaseType;
                var type = baseType == typeof(MedicalAppointmentReportSessionEvent)
                    ? session.Events[i].GetType()
                    : baseType;

                if (type == eventType)
                {
                    //Edge case for Choosing date
                    if (type == typeof(GoneBackToSelection))
                    {
                        GoneBackToSelection backToSelectionEvent =
                            (GoneBackToSelection)_medAppSessionRepository.GetEventById(session.Events[i].Id);
                        if (backToSelectionEvent.Selection != SelectionReport.Symptom)
                        {
                            return 0;
                        }
                    }

                    //This can happen when you have ChosenDoctor and customer doesn't finish scheduling
                    if (i + 1 >= session.Events.Count()) continue;

                    timeSpent += session.Events[i + 1].OccurrenceTime.Subtract(session.Events[i].OccurrenceTime)
                        .TotalSeconds;
                }
            }
            return timeSpent;
        }

        private double GetSpentTimeOnSesion(MedicalAppointmentReportSession session)
        {
            double timeSpent = 0;

            for (int i = 0; i < session.Events.Count(); i++)
            {
                //Base type is accesed because EF sometimes returns proxy of an object
                var baseType = session.Events[i].GetType().BaseType;
                var type = baseType == typeof(MedicalAppointmentReportSessionEvent)
                    ? session.Events[i].GetType()
                    : baseType;
                if (i + 1 >= session.Events.Count()) continue;
                timeSpent += session.Events[i + 1].OccurrenceTime.Subtract(session.Events[i].OccurrenceTime)
                        .TotalSeconds;
                
            }
            return timeSpent;
        }

    }
}
