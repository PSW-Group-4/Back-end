using IntegrationLibrary.Common;
using System;

namespace HospitalAPI.RabbitMqPaket
{
    public class ContractDTO
    {
        public ContractDTO()
        {

        }
        public string id { get; set; }
        public int bloodGroup { get; set; }
        public int quantity { get; set; }
        public int deliveryDay { get; set; }
        public string queueName { get; set; }
    }
}
