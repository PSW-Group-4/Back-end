using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tenders.Model;
using System;

namespace IntegrationAPI.Dtos.Tenders
{
    public class TenderConverter : IConverter<Tender, TenderDto>
    {
        public TenderDto Convert(Tender entity)
        {
            return new TenderDto
            {
                Amount = entity.Amount,
                BloodType = entity.BloodType.ToString(),
                RHFactor = entity.RHFactor.ToString(),
                Deadline = entity.Deadline.ToString()
            };
        }

        public Tender Convert(TenderDto dto)
        {
            return new Tender(
                (BloodType) Enum.Parse(typeof(BloodType), dto.BloodType),
                (RHFactor) Enum.Parse(typeof(RHFactor), dto.RHFactor),
                dto.Amount,
                DateTime.Now,
                DateTime.Parse(dto.Deadline));
        }
    }
}
