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
using HospitalAPI.Controllers.Dtos.Doctor;
using HospitalLibrary.Doctors.Model;
using HospitalAPI.Controllers.Dtos.Appointment;
using HospitalLibrary.Appointments.Model;

namespace HospitalAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRequestDto, Address>();
            CreateMap<PersonRequestDto, Person>();

            CreateMap<PatientRequestDto, Patient>()
                .IncludeBase<PersonRequestDto, Person>();
            CreateMap<FeedbackRequestDto, Feedback>();
            CreateMap<Feedback, FeedbackPatientResponseDto>().ForMember(dest => dest.PatientFullname,
                    opt => opt.MapFrom(src => ResolveFeedbackPatientFullName(src)));
            CreateMap<Feedback, FeedbackManagerResponseDto>().ForMember(dest => dest.PatientFullname,
                    opt => opt.MapFrom(src => ResolveFeedbackPatientFullName(src)));
        }

        private static string ResolveFeedbackPatientFullName(Feedback src)
        {
                    if (src.IsAnonimous)
                    {
                        return "Anonymous";
                    }
                    return src.Patient.Name + " " + src.Patient.Surname;
        }
            CreateMap<MapItemRequestDto, MapItem>();

            CreateMap<PatientRequestDTO, Patient>()
                .IncludeBase<PersonRequestDto, Person>();

            CreateMap<BuildingMapRequestDto,BuildingMap>()
                .IncludeBase<MapItemRequestDto,MapItem>();

            CreateMap<FloorMapRequestDto, FloorMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<RoomMapRequestDto, RoomMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<DoctorRequestDto, Doctor>()
                .IncludeBase<PersonRequestDto, Person>();

            CreateMap<RoomRequestDto, Room>();
            CreateMap<AppointmentRequestDto, Appointment>();

        }
    }
}