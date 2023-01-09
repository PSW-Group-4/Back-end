using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Repository;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Service
{
    public class MedAppSchedulingStatisticsService : IMedAppSchedulingStatisticsService
    {

        private readonly IMedicalAppointmentSchedulingSessionRepository _medAppSessionRepository;
        private readonly IAgeGroupRepository _ageGroupRepository;

        public MedAppSchedulingStatisticsService(IMedicalAppointmentSchedulingSessionRepository medAppSessionRepository, IAgeGroupRepository ageGroupRepository)
        {
            _medAppSessionRepository = medAppSessionRepository;
            _ageGroupRepository = ageGroupRepository;
        }
        
        
        public IDictionary<Selection, int> GetTimesPerSelection()
        {
            IEnumerable<MedicalAppointmentSchedulingSession> sessions = _medAppSessionRepository.GetAll();

            IDictionary<Selection, int> timesPerSelection = new Dictionary<Selection, int>();
            foreach (Selection selection in Enum.GetValues(typeof(Selection)))
            {
               timesPerSelection.Add(selection, 0); 
            }

            if (!sessions.Any()) return timesPerSelection;

            foreach (MedicalAppointmentSchedulingSession session in sessions)
            {
                timesPerSelection[Selection.Date] += CountTimesAtDateSelection(session);
                timesPerSelection[Selection.Speciality] += CountTimesAtSpecialitySelection(session);
                timesPerSelection[Selection.Doctor] += CountTimesAtDoctorSelection(session);
                timesPerSelection[Selection.Time] += CountTimesAtTimeSelection(session);
            }

            foreach (var count in timesPerSelection)
            {
                timesPerSelection[count.Key] = count.Value / sessions.Count();
            }

            return timesPerSelection;
        }

        //Time is measured in seconds
        public IDictionary<Selection, double> GetSpentTimePerSelection()
        {
            IEnumerable<MedicalAppointmentSchedulingSession> sessions = _medAppSessionRepository.GetAll();

            IDictionary<Selection, double> timeSpentPerSelection = new Dictionary<Selection, double>();
            foreach (Selection selection in Enum.GetValues(typeof(Selection)))
            {
               timeSpentPerSelection.Add(selection, 0); 
            }
            if (!sessions.Any()) return timeSpentPerSelection;

            foreach (MedicalAppointmentSchedulingSession session in sessions)
            {
                timeSpentPerSelection[Selection.Date] += GetSpentTime(session, typeof(StartedScheduling));
                timeSpentPerSelection[Selection.Date] += GetSpentTime(session, typeof(GoneBackToSelection));
                timeSpentPerSelection[Selection.Speciality] += GetSpentTime(session, typeof(ChosenDate));
                timeSpentPerSelection[Selection.Doctor] += GetSpentTime(session, typeof(ChosenSpeciality));
                timeSpentPerSelection[Selection.Time] += GetSpentTime(session, typeof(ChosenDoctor));
            }
            
            foreach (var count in timeSpentPerSelection)
            {
                timeSpentPerSelection[count.Key] = count.Value / sessions.Count();
            }
            return timeSpentPerSelection;
        }
        
        private string GetAgeGroupLabel(AgeGroup ageGroup)
        {
            return ageGroup.GropuName + "(" + ageGroup.MinAge + " - " + ageGroup.MaxAge + ")";
        }
        //Time is measured in seconds
        public IDictionary<string, double> GetTotalSpentTimePerAgeGroup()
        {
            List<AgeGroup> ageGroups = _ageGroupRepository.GetAll().ToList();
            List<MedicalAppointmentSchedulingSession> sessions = _medAppSessionRepository.GetAll().ToList();

            IDictionary<string, double> timePerAgeGroup = new Dictionary<string, double>();
            IDictionary<string, int> ageGroupCounter = new Dictionary<string, int>();

            foreach (AgeGroup ageGroup in ageGroups)
            {
                string label = GetAgeGroupLabel(ageGroup);
                timePerAgeGroup.Add(label, 0); 
                ageGroupCounter.Add(label, 0); 
            }

            foreach (MedicalAppointmentSchedulingSession session in sessions)
            {
                double spentTime = session.Events.Max(e => e.OccurrenceTime)
                    .Subtract(session.Events.Min(e => e.OccurrenceTime)).TotalSeconds;

                int patientsAge = session.Patient.GetAge();
                AgeGroup ageGroup = ageGroups.SingleOrDefault(ag => patientsAge  >= ag.MinAge &&  patientsAge <= ag.MaxAge);

                string ageGroupLabel = GetAgeGroupLabel(ageGroup);
                timePerAgeGroup[ageGroupLabel] += spentTime;
                ageGroupCounter[ageGroupLabel]++;
            }

            foreach (AgeGroup ageGroup in ageGroups)
            {
                string label = GetAgeGroupLabel(ageGroup);
                if(ageGroupCounter[label] == 0) continue;
                
                timePerAgeGroup[label] = timePerAgeGroup[label] / ageGroupCounter[label];
            }

            return timePerAgeGroup;
        }


        public IDictionary<string, int> GetTotalStepsPerAgeGroup()
        {
            List<AgeGroup> ageGroups = _ageGroupRepository.GetAll().ToList();
            List<MedicalAppointmentSchedulingSession> sessions = _medAppSessionRepository.GetAll().ToList();

            IDictionary<string, int> stepsPerAgeGroup = new Dictionary<string, int>();
            IDictionary<string, int> ageGroupCounter = new Dictionary<string, int>();

            foreach (AgeGroup ageGroup in ageGroups)
            {
                string label = GetAgeGroupLabel(ageGroup);
                stepsPerAgeGroup.Add(label, 0); 
                ageGroupCounter.Add(label, 0); 
            }

            foreach (MedicalAppointmentSchedulingSession session in sessions)
            {
                //Start of scheduling is not counted
                int totalSteps = session.Events.Count()-1;

                int patientsAge = session.Patient.GetAge();
                AgeGroup ageGroup = ageGroups.SingleOrDefault(ag => patientsAge  >= ag.MinAge &&  patientsAge <= ag.MaxAge);

                string ageGroupLabel = GetAgeGroupLabel(ageGroup);
                stepsPerAgeGroup[ageGroupLabel] += totalSteps;
                ageGroupCounter[ageGroupLabel]++;
            }

            foreach (AgeGroup ageGroup in ageGroups)
            {
                string label = GetAgeGroupLabel(ageGroup);
                if(ageGroupCounter[label] == 0) continue;
                
                stepsPerAgeGroup[label] = stepsPerAgeGroup[label] / ageGroupCounter[label];
            }

            return stepsPerAgeGroup;
        }

        public IDictionary<string, double> GetSchedulingSuccessRatePerAgeGroup()
        {
            List<AgeGroup> ageGroups = _ageGroupRepository.GetAll().ToList();
            List<MedicalAppointmentSchedulingSession> sessions = _medAppSessionRepository.GetAll().ToList();

            IDictionary<string, double> successfulSchedulingsPerAgeGroup = new Dictionary<string, double>();
            IDictionary<string, int> ageGroupCounter = new Dictionary<string, int>();

            foreach (AgeGroup ageGroup in ageGroups)
            {
                string label = GetAgeGroupLabel(ageGroup);
                successfulSchedulingsPerAgeGroup.Add(label, 0); 
                ageGroupCounter.Add(label, 0); 
            }

            foreach (MedicalAppointmentSchedulingSession session in sessions)
            {
                bool successfulScheduling = false;
                //Base type is accessed because EF sometimes returns proxy of an object
                if (session.Events[0].GetType().BaseType == typeof(MedicalAppointmentSchedulingSessionEvent))
                {
                    successfulScheduling = session.Events.Any(e => e.GetType() == typeof(FinishedScheduling));
                }
                else
                {
                    successfulScheduling = session.Events.Any(e => e.GetType().BaseType == typeof(FinishedScheduling));
                }

                int patientsAge = session.Patient.GetAge();
                AgeGroup ageGroup = ageGroups.SingleOrDefault(ag => patientsAge  >= ag.MinAge &&  patientsAge <= ag.MaxAge);

                string ageGroupLabel = GetAgeGroupLabel(ageGroup);
                successfulSchedulingsPerAgeGroup[ageGroupLabel] += successfulScheduling ? 1 : 0;
                ageGroupCounter[ageGroupLabel]++;
            }

            foreach (AgeGroup ageGroup in ageGroups)
            {
                string label = GetAgeGroupLabel(ageGroup);
                if(ageGroupCounter[label] == 0) continue;
                
                successfulSchedulingsPerAgeGroup[label] = successfulSchedulingsPerAgeGroup[label] / ageGroupCounter[label] * 100;
            }

            return successfulSchedulingsPerAgeGroup;
        }

        public IDictionary<string, int> GetNumberOfChoosesPerDoctor()
        {
            IDictionary<Doctor, int> choosesPerDoctor = _medAppSessionRepository.GetNumberOfChoosesPerDoctor();
            IDictionary<string, int> choosesPerDoctorFullName = new Dictionary<string, int>();

            //Name and surname may not be unique but groups are retrieved from db by DoctorId so there are no oversights
            foreach (KeyValuePair<Doctor, int> doctorChoosesCount in choosesPerDoctor)
            {
                string fullname = doctorChoosesCount.Key.Name + " " + doctorChoosesCount.Key.Surname;
                choosesPerDoctorFullName.Add(fullname, doctorChoosesCount.Value);
            }

            return choosesPerDoctorFullName;
        }


        private int CountTimesAtDateSelection(MedicalAppointmentSchedulingSession session)
        {
            
                int timesAtDateSelection = session.Events
                    .OfType<StartedScheduling>().Count();
                
                timesAtDateSelection += session.Events
                    .OfType<GoneBackToSelection>().Count(e => e.Selection == Selection.Date);

                return timesAtDateSelection;
        }

        private int CountTimesAtSpecialitySelection(MedicalAppointmentSchedulingSession session)
        {
            
                int timesAtSpecialitySelection = session.Events
                    .OfType<ChosenDate>().Count();
                
                timesAtSpecialitySelection += session.Events
                    .OfType<GoneBackToSelection>().Count(e => e.Selection == Selection.Speciality);

                return timesAtSpecialitySelection;
        }

        private int CountTimesAtDoctorSelection(MedicalAppointmentSchedulingSession session)
        {
            
                int timesAtDoctorSelection = session.Events
                    .OfType<ChosenSpeciality>().Count();
                
                timesAtDoctorSelection += session.Events
                    .OfType<GoneBackToSelection>().Count(e => e.Selection == Selection.Doctor);

                return timesAtDoctorSelection;
        }

        private int CountTimesAtTimeSelection(MedicalAppointmentSchedulingSession session)
        {
            
                int timesAtTimeSelection = session.Events
                    .OfType<ChosenDoctor>().Count();
                
                timesAtTimeSelection += session.Events
                    .OfType<GoneBackToSelection>().Count(e => e.Selection == Selection.Time);

                return timesAtTimeSelection;
        }

        //Time is measured in seconds
        private double GetSpentTime(MedicalAppointmentSchedulingSession session, Type eventType )
        {
            double timeSpent = 0;
            
            for (int i = 0; i < session.Events.Count(); i++)
            {
                //Base type is accesed because EF sometimes returns proxy of an object
                var baseType = session.Events[i].GetType().BaseType;
                var type = baseType == typeof(MedicalAppointmentSchedulingSessionEvent)
                    ? session.Events[i].GetType()
                    : baseType; 
                
                if (type == eventType)
                {
                    //Edge case for Choosing date
                    if (type == typeof(GoneBackToSelection))
                    {
                        GoneBackToSelection backToSelectionEvent =
                            (GoneBackToSelection) _medAppSessionRepository.GetEventById(session.Events[i].Id);
                        if (backToSelectionEvent.Selection != Selection.Date)
                        {
                            return 0;
                        }
                    }
                    
                    //This can happen when you have ChosenDoctor and customer doesn't finish scheduling
                   if(i + 1 >= session.Events.Count()) continue;
                   
                    timeSpent += session.Events[i + 1].OccurrenceTime.Subtract(session.Events[i].OccurrenceTime)
                        .TotalSeconds;
                }
            }
            return timeSpent;
        }
    }
}