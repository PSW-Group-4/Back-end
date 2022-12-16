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
        IEnumerable<Vacation> GetAllManager();
        Vacation GetById(Guid id);
        Vacation Create(Vacation vacation);
        Vacation Update(Vacation vacation);
        void Delete(Guid vacationId);
        IEnumerable<Vacation> GetDoctorVacationsFromSpecificStatus(VacationStatus vacationStatus, Guid DoctorId);
        IEnumerable<Vacation> GetAllPastByDoctorId(Guid doctorId);
        public List<int> GetNumberOfVacationsPerMonth(Guid doctorId);

    }
}
