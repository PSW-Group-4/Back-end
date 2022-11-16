using AutoMapper;
using HospitalAPI.Dtos.Address;
using HospitalAPI.Dtos.Feedback;
using HospitalAPI.Dtos.Patient;
using HospitalAPI.Dtos.Person;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalAPI.Dtos.Appointment;
using HospitalAPI.Dtos.Doctor;
using HospitalAPI.Dtos.MapItem;
using HospitalAPI.Dtos.Rooms;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Appointments.Model;
using HospitalAPI.Dtos.User;
using HospitalLibrary.Users.Model;
using HospitalAPI.Dtos.BloodConsumptionRecord;
using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalAPI.Dtos.Vacation;
using HospitalLibrary.Vacations.Model;
using HospitalAPI.Dtos.BloodSupply;
using HospitalLibrary.BloodSupplies.Model;

namespace HospitalAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRequestDto, Address>();

            CreateMap<PersonRequestDto, Person>();
            CreateMap< Person , PersonRequestDto>();

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

            CreateMap<Doctor , DoctorRequestDto> ()
                .IncludeBase<Person , PersonRequestDto>();

            CreateMap<RoomRequestDto, Room>();
            CreateMap<AppointmentRequestDto, Appointment>();
            CreateMap<VacationRequestDto, Vacation>();

            CreateMap<BloodConsumptionRecordRequestDto, BloodConsumptionRecord>();
            CreateMap<BloodSupplyDto, BloodSupply>();

            CreateMap<PatientRegistrationDto, Patient>();
            CreateMap<UserLoginDto, User>();
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
