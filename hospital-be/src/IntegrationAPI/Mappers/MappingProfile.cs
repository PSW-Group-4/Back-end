using AutoMapper;
using IntegrationAPI.Dtos.BloodBank;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.Tenders.Model;

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
            CreateMap<BloodProductDto, BloodProduct>();
        }
    }
}
