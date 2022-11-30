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
                BloodGroup = entity.BloodType.ToString(),
                Deadline = entity.Deadline.ToString()
            };
        }

        public Tender Convert(TenderDto dto)
        {
            BloodType bloodType = new((BloodGroup)Enum.Parse(typeof(BloodGroup), dto.BloodGroup),
                (RHFactor)Enum.Parse(typeof(RHFactor), dto.RHFactor));
            return Tender.Create(bloodType,
                dto.Amount,
                DateTime.Parse(dto.Deadline));
        }
    }
}
