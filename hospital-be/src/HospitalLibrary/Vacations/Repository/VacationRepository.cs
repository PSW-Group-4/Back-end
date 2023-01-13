using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;
using HospitalLibrary.Vacations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Vacations.Repository
{
    public class VacationRepository : IVacationRepository
    {
        private readonly HospitalDbContext _context;

        public VacationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _context.Vacations.ToList(); //.OrderBy(x => x.DateEnd);
        }

        public IEnumerable<Vacation> GetAllManager()
        {
            return _context.Vacations.ToList().OrderBy(x => x.DateEnd); 
        }

        public Vacation GetById(Guid id)
        {
            var result = _context.Vacations.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Vacation Update(Vacation vacation)
        {
            var updatingVacation = _context.Vacations.FirstOrDefault(p => p.Id == vacation.Id);
            if (updatingVacation == null)
            {
                throw new NotFoundException();
            }

            updatingVacation.Update(vacation);
            _context.SaveChanges();
            return updatingVacation;
        }
        public Vacation Create(Vacation vacation)
        {
            _context.Vacations.Add(vacation);
            _context.SaveChanges();
            return vacation;
        }

        public void Delete(Guid id)
        {
            var vacation = GetById(id);
            _context.Vacations.Remove(vacation);
            _context.SaveChanges();
        }

public bool IsDoctorOnVacation(Guid doctorId, DateTime date)
        {

            IEnumerable<Vacation> doctorVacations = GetAll();
            foreach (Vacation v in doctorVacations)
            {
                if (v.DoctorId == doctorId
                    && v.VacationStatus == VacationStatus.Approved
                    &&DateTime.Compare(date, v.DateStart) > 0
                    && DateTime.Compare(date, v.DateEnd) < 0 )
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Vacation> GetAllPastByDoctorId(Guid doctorId)
        {
            return _context.Vacations.Where(x => x.DoctorId == doctorId && x.DateEnd < DateTime.Now && x.VacationStatus == VacationStatus.Approved).ToList();
        }
    }
}
