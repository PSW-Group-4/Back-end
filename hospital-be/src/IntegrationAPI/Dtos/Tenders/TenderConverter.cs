using AutoMapper;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tenders.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationAPI.Dtos.Tenders
{
    public class TenderConverter : IConverter<Tender, TenderDto>
    {

        public TenderConverter() { }

        public TenderDto Convert(Tender entity)
        {
            IEnumerable<BloodProductDto> bloodProductDtos = entity.BloodProducts.Select(bloodProduct => new BloodProductDto { Amount = bloodProduct.Amount, BloodType = bloodProduct.BloodType.ToString() });
            return new TenderDto
            {
                BloodProducts = entity.BloodProducts.Select(bloodProduct => new BloodProductDto { Amount = bloodProduct.Amount, BloodType = bloodProduct.BloodType.ToString() }),
                Deadline = entity.Deadline.ToString()
            };
        }

        public Tender Convert(TenderDto dto)
        {
            IEnumerable<BloodProduct> bloodProducts = dto.BloodProducts.Select(dto => new BloodProduct(BloodType.O, dto.Amount));
            return Tender.Create(bloodProducts,
                DateTime.Parse(dto.Deadline));
        }
    }
}
