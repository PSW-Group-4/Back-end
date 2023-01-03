using AutoMapper;
using IntegrationAPI.Dtos.BloodTypes;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationAPI.Dtos.Tenders
{
    public class TenderConverter : IConverter<Tender, TenderDto>
    {

        public TenderConverter() { }

        public TenderDto Convert(Tender entity)
        {
            //IEnumerable<BloodProductDto> bloodProductDtos = entity.Blood.Select(bloodProduct => new BloodProductDto { Amount = bloodProduct.Amount, BloodType = bloodProduct.BloodType.ToString() });
            /*return new TenderDto
            {
                Blood = entity.Blood.Select(bloodProduct => new BloodProductDto { Amount = bloodProduct.Amount, BloodType = bloodProduct.BloodType.ToString() }),
                Deadline = entity.Deadline.ToString()
            };*/
            return new TenderDto();
        }

        public Tender Convert(TenderDto dto)
        {
            DateTime? deadline;
            if(dto.Deadline != null)
            {
                deadline = DateTime.Parse(dto.Deadline);
            } else
            {
                deadline = null;
            }
            IEnumerable<Blood> bloodProducts = dto.Blood.Select
                (dto => new Blood(
                    BloodTypeConverter.Convert(dto.BloodType),
                    dto.Amount));;
            return Tender.Create(bloodProducts,
                deadline);
        }
         
    }
}
