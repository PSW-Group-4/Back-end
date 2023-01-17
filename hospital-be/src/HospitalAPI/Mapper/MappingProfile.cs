using AutoMapper;
using HospitalAPI.Dtos.Address;
using HospitalAPI.Dtos.Admission;
using HospitalAPI.Dtos.AdmissionHistory;
using HospitalAPI.Dtos.Allergies;
using HospitalAPI.Dtos.Appointment;
using HospitalAPI.Dtos.Bed;
using HospitalAPI.Dtos.BloodConsumptionRecord;
using HospitalAPI.Dtos.BloodSupply;
using HospitalAPI.Dtos.Consilium;
using HospitalAPI.Dtos.DateRange;
using HospitalAPI.Dtos.Doctor;
using HospitalAPI.Dtos.Feedback;
using HospitalAPI.Dtos.MapItem;
using HospitalAPI.Dtos.Medicine;
using HospitalAPI.Dtos.Patient;
using HospitalAPI.Dtos.Person;
using HospitalAPI.Dtos.Prescription;
using HospitalAPI.Dtos.Report;
using HospitalAPI.Dtos.Rooms;
using HospitalAPI.Dtos.Symptom;
using HospitalAPI.Dtos.Treatment;
using HospitalAPI.Dtos.User;
using HospitalAPI.Dtos.Vacation;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Treatments.Model;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Vacations.Model;
using HospitalAPI.Dtos.Renovation;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Utility;

namespace HospitalAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRequestDto, Address>();
            CreateMap<Address, AddressRequestDto>();

            CreateMap<PersonRequestDto, Person>();
            CreateMap<Person, PersonRequestDto>();
            CreateMap<Person, PersonFullnameDto>().ForMember(dest => dest.Fullname,
                opt => opt.MapFrom(src => src.Surname + " " + src.Name));

            CreateMap<Person, PersonRequestDto>().ForMember( p => p.Email,
                opt => opt.MapFrom(src => src.Email.Address ));
            CreateMap<PatientRequestDto, Patient>()
                .IncludeBase<PersonRequestDto, Person>();
            CreateMap<FeedbackRequestDto, Feedback>();
            CreateMap<Feedback, FeedbackPatientResponseDto>().ForMember(dest => dest.PatientFullname,
                opt => opt.MapFrom(src => ResolveFeedbackPatientFullName(src)));
            CreateMap<Feedback, FeedbackManagerResponseDto>().ForMember(dest => dest.PatientFullname,
                opt => opt.MapFrom(src => ResolveFeedbackPatientFullName(src)));


            CreateMap<MapItemRequestDto, MapItem>();

            CreateMap<PatientRequestDto, Patient>()
                .IncludeBase<PersonRequestDto, Person>();

            CreateMap<BuildingMapRequestDto, BuildingMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<FloorMapRequestDto, FloorMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<RoomMapRequestDto, RoomMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<DoctorRequestDto, Doctor>()
                .IncludeBase<PersonRequestDto, Person>();

            CreateMap<Doctor, DoctorRequestDto>().IncludeBase<Person, PersonRequestDto>();

            CreateMap<RoomRequestDto, Room>();
            CreateMap<Room, RoomRequestDto>();

            //CreateMap<PatientRoom, PatientRoomRequestDto>().IncludeBase<Room, RoomRequestDto>();
            CreateMap<PatientRoomRequestDto, PatientRoom>().IncludeBase<RoomRequestDto, Room>();

            CreateMap<AppointmentRequestDto, MedicalAppointment>().ForMember(dest=> dest.DateRange,
                opt => opt.MapFrom(src => new DateRange(src.StartTime,src.StartTime.AddMinutes(30))));

            CreateMap<AppointmentRequestPatientDto, MedicalAppointment>().ForMember(dest => dest.DateRange,
                opt => opt.MapFrom(src => new DateRange(src.Date, src.Date.AddMinutes(30))));

            CreateMap<VacationRequestDto, Vacation>();

            CreateMap<BloodConsumptionRecordRequestDto, BloodConsumptionRecord>();
            CreateMap<BloodConsumptionRecord, BloodConsumptionRecordRequestDto>().ForMember(dest => dest.Amount, 
                opt => opt.MapFrom(src => src.Amount.Value));
            CreateMap<BloodSupplyDto, BloodSupply>();
            CreateMap<Feedback, FeedbackPatientResponseDto>().ForMember(dest => dest.PatientFullname,
                opt => opt.MapFrom(src => ResolveFeedbackPatientFullName(src)));


            CreateMap<Person, PersonGetResponseDto>().ForMember( p => p.Email,
                opt => opt.MapFrom(src => src.Email.Address ));
            
            CreateMap<PatientRegistrationDto, Patient>();
            CreateMap<Patient, PatientGetResponseDto>()
                .IncludeBase<Person, PersonGetResponseDto>();
            
            CreateMap<UserLoginDto, User>();
            CreateMap<UserDto, User>();

            CreateMap<Patient, PatientInfoDto>().IncludeBase<Person, PersonRequestDto>();
            CreateMap<PatientInfoDto, Patient>().IncludeBase<PersonRequestDto, Person>();

            CreateMap<AllergieInfoDto, Allergie>();
            CreateMap<Allergie, AllergieInfoDto>();


            CreateMap<BedDto, Bed>();
            CreateMap<Bed, BedDto>();

            CreateMap<AdmissionRequestDto, Admission>();
            CreateMap<Admission, AdmissionRequestDto>();
            CreateMap<Admission, AdmissionRequestDto>().ForMember(dest => dest.ReasonText,
                opt => opt.MapFrom(src => src.ReasonText.Text));

            CreateMap<MedicineRequestDto, Medicine>();
            CreateMap<Medicine, MedicineRequestDto>();

            CreateMap<SymptomRequestDto, Symptom>();
            CreateMap<Symptom, SymptomRequestDto>();

            CreateMap<PrescriptionRequestDto, Prescription>();
            CreateMap<Prescription, PrescriptionRequestDto>();

            CreateMap<ReportRequestDto, Report>();
            CreateMap<Report, ReportRequestDto>();

            CreateMap<TreatmentRequestDto, Treatment>();
            CreateMap<Treatment, TreatmentRequestDto>();

            CreateMap<TreatmentUpdateDto, Treatment>();
            CreateMap<Treatment, TreatmentUpdateDto>();

            CreateMap<AdmissionUpdateTreatmentDto, Admission>();
            CreateMap<Admission, AdmissionUpdateTreatmentDto>();


            CreateMap<AdmissionHistoryRequestDto, AdmissionHistory>();

            CreateMap<AppointmentDto, Appointment>();
            CreateMap<DateRangeDto, DateRange>();

            CreateMap<ConsiliumRequestDto, ConsiliumRequest>();

            CreateMap<RenovationAppointmentDto, RenovationDataDto>();
            CreateMap<RoomRenovationPlanDto, RoomRenovationPlan>();

            CreateMap<AppointmentRequestWithSuggestionsDto, RequestForAppointmentSlotSuggestions>();

        }

        private static string ResolveFeedbackPatientFullName(Feedback src)
        {
            if (src.IsAnonimous)
            {
                return "Anonymous";
            }
            return src.Patient.Name + " " + src.Patient.Surname;
        }
    }
}
