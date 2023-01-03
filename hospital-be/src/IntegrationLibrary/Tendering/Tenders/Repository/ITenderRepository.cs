using System;
using System.Collections.Generic;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationLibrary.Tendering.Repository
{
    public interface ITenderRepository
    {
        void Create(Tender tender);
        IEnumerable<Tender> GetAll();
        Tender GetById(Guid Id);
    }
}
