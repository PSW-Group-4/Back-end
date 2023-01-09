using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;

namespace HospitalLibrary.RenovationSessionAggregate.Repository.Interfaces
{
    public interface IRenovationSessionEventRepository : IRepositoryBase<RenovationSessionEvent>
    {
        
    }
}