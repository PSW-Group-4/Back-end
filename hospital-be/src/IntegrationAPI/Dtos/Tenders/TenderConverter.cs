using AutoMapper;
using IntegrationAPI.Dtos.BloodTypes;
using IntegrationLibrary.Common;
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
            //IEnumerable<BloodProductDto> bloodProductDtos = entity.BloodProducts.Select(bloodProduct => new BloodProductDto { Amount = bloodProduct.Amount, BloodType = bloodProduct.BloodType.ToString() });
            /*return new TenderDto
            {
                BloodProducts = entity.BloodProducts.Select(bloodProduct => new BloodProductDto { Amount = bloodProduct.Amount, BloodType = bloodProduct.BloodType.ToString() }),
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
            IEnumerable<BloodProduct> bloodProducts = dto.BloodProducts.Select
                (dto => new BloodProduct(
                    BloodTypeConverter.Convert(dto.BloodType),
                    dto.Amount));;
            return Tender.Create(bloodProducts,
                deadline);
        }
         
    }
}
