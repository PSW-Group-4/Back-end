using AutoMapper;
using HospitalAPI.Controllers.Dtos.Address;
using HospitalAPI.Controllers.Dtos.Doctor;
using HospitalAPI.Controllers.Dtos.Patient;
using HospitalAPI.Controllers.Dtos.Person;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
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
            CreateMap<DoctorRequestDto, Doctor>()
                .IncludeBase<PersonRequestDto, Person>();
        }
    }
}