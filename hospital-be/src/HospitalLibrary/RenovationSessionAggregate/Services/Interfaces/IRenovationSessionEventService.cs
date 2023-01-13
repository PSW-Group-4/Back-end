using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;

namespace HospitalLibrary.RenovationSessionAggregate.Services.Interfaces
{
    public interface IRenovationSessionEventService : ICrudService<RenovationSessionEvent> 
    {
        public IEnumerable<RenovationSessionEvent> GetAllForRootId(Guid id);
    }
}