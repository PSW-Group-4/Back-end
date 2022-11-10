using HospitalLibrary.Vacations.Model;
using HospitalLibrary.Vacations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Vacations.Service
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepository;

        public VacationService(IVacationRepository vacationRepository)
        {
            _vacationRepository = vacationRepository;
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationRepository.GetAll();
        }

        public Vacation GetById(Guid id)
        {
            return _vacationRepository.GetById(id);
        }
        public Vacation Create(Vacation vacation)
        {
            return _vacationRepository.Create(vacation);
        }

        public void Delete(Guid vacationId)
        {
            _vacationRepository.Delete(vacationId);
        }

        public Vacation Update(Vacation vacation)
        {
            return _vacationRepository.Update(vacation);
        }
    }
}
