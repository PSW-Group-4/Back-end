using AutoMapper;
using AutoMapper.Internal.Mappers;
using HospitalAPI.Controllers.Dtos.Address;
using HospitalAPI.Controllers.Dtos.Patient;
using HospitalAPI.Controllers.Dtos.Person;
using HospitalAPI.Dtos.Feedback;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Patients.Model;
using Microsoft.OpenApi.Expressions;

namespace HospitalAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRequestDto, Address>();
            CreateMap<PersonRequestDto, Person>();
            CreateMap<PatientRequestDTO, Patient>()
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
    }
}