using System;
using System.Collections.Generic;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationLibrary.Tendering.Service
{
    public interface ITenderService
    {
        void Create(Tender tender);
        IEnumerable<Tender> GetAll();
        Tender GetById(Guid Id);
        IEnumerable<Tender> GetActive();
    }
}
