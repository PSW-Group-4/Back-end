using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Appointments.Service
{
    public interface IDoctorAppointmentService
    {
        IEnumerable<MedicalAppointment> GetDoctorAppointments(Guid id);
        IEnumerable<MedicalAppointment> GetDoctorsOldAppointments(Guid id);
        IEnumerable<MedicalAppointment> GetDoctorsCurrentAppointments(Guid id);
        void deleteAppointmentEndSendNotification(Guid id);
        List<DateRange> AvailableTerminsForDate(DateTime date, Guid patientId, Guid doctorId);
        bool IsDoctorAvailable(Guid doctorId, DateTime time);
        public List<DateRange> getAvailableTerminsForAnotherDoctor(DateTime timeStart, DateTime timeEnd, Guid patientId, Guid doctorId);
        public List<AppointmentSuggestionsWithTheirDoctors> GetAppointmentSuggestionsForDateRange(
            RequestForAppointmentSlotSuggestions request);

        public List<int> GetAppointmentsPerYear(Guid doctorId, int selectedYear);
        public List<int> GetAppointmentsPerMonth(Guid doctorId, int selectedYear, int selectedMonth);

    }
}
