using HospitalLibrary.Vacations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Vacations.Service
{
    public interface IVacationService
    {
        IEnumerable<Vacation> GetAll();
        Vacation GetById(Guid id);
        Vacation Create(Vacation vacation);
        Vacation Update(Vacation vacation);
        void Delete(Guid vacationId);
    }
}
