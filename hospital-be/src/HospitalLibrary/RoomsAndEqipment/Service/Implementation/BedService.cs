using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Service.Implementation
{
    public class BedService : IBedService
    {
        private readonly IBedRepository _bedRepository;
        public BedService(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

        public IEnumerable<Bed> GetAll()
        {
            return _bedRepository.GetAll();
        }

        public Bed GetById(Guid id)
        {
            return _bedRepository.GetById(id);
        }

        public Bed Create(Bed bed)
        {
            return _bedRepository.Create(bed);
        }

        public Bed Update(Bed bed)
        {
            return _bedRepository.Update(bed);
        }

        public void Delete(Guid bedId)
        {
            _bedRepository.Delete(bedId);
        }
        public Bed FreeBed(Bed bed)
        {
            return _bedRepository.FreeBed(bed);
        }
        public Bed CaptureBed(Bed bed)
        {
            return _bedRepository.CaptureBed(bed);
        }
    }
}
