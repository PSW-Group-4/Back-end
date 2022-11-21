using AutoMapper;
using IntegrationAPI.Dtos.BloodBank;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodRequests.Model;

namespace IntegrationAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BloodBankRegisterDto, BloodBank>();
            CreateMap<BloodBankEditDto, BloodBank>();
            CreateMap<BloodRequestEditDto, BloodRequest>();
            CreateMap<BloodRequestsCreateDto, BloodRequest>();
        }
    }
}
