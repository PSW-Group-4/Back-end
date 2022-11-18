using AutoMapper;
using IntegrationAPI.Dtos.BloodBank;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationAPI.Dtos.BloodRequests;

namespace IntegrationAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BloodBankRegisterDto, BloodBank>();
            CreateMap<BloodBankEditDto, BloodBank>();
            CreateMap<BloodRequestsCreateDto, BloodRequest>();
        }
    }
}
