﻿using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Service
{
    public interface IBloodBankService
    {
        public IEnumerable<BloodBank> GetAll();
        public BloodBank GetById(Guid id);
        public BloodBank Create(BloodBank bloodBank);
    }
}
