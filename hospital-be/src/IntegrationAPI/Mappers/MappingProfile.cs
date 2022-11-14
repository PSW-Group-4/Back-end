using AutoMapper;
using IntegrationAPI.Dtos.BloodBank;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Model;

namespace IntegrationAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BloodBankRegisterDto, BloodBank>();
            CreateMap<BloodBankEditDto, BloodBank>();
        }
    }
}
