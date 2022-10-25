using AutoMapper;
using HospitalAPI.Controllers.Dtos.Address;
using HospitalAPI.Controllers.Dtos.Feedback;
using HospitalAPI.Controllers.Dtos.Patient;
using HospitalAPI.Controllers.Dtos.Person;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Patients.Model;

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
        }
    }
}