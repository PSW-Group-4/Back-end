using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Consiliums.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Consiliums.Service
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;
        public ConsiliumService(IConsiliumRepository consiliumRepository)
        {
            _consiliumRepository = consiliumRepository;
        }
        // DJOLE TODO
        public ConsiliumRequest Create(ConsiliumRequest consiliumRequest)
        {
            throw new NotImplementedException();
        }
        // PETAR TODO
        public IEnumerable<Consilium> GetDoctorsConsiliums(Guid DoctorId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Consilium> GetAll()
        {
            return _consiliumRepository.GetAll();
        }

        public Consilium GetById(Guid id)
        {
            return _consiliumRepository.GetById(id);
        }

        
    }
}
