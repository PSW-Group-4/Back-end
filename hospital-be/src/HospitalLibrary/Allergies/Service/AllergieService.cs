using AutoMapper;
using HospitalLibrary.Allergies.Repository;
using HospitalLibrary.Allergies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Allergies.Service
{
    public class AllergieService : IAllergieService
    {
        private readonly IAllergieRepository _allergieRepository;

        public AllergieService(IAllergieRepository allergieRepository)
        {
            _allergieRepository = allergieRepository;
        }

        public IEnumerable<Allergie> GetAll()
        {
            return _allergieRepository.GetAll();
        }

        public Allergie GetById(Guid id)
        {
            return _allergieRepository.GetById(id);
        }

        public Allergie Create(Allergie allergie)
        {
            return _allergieRepository.Create(allergie);
        }

        public Allergie Update(Allergie allergie)
        {
            return _allergieRepository.Update(allergie);
        }

        public void Delete(Guid allergieId)
        {
            _allergieRepository.Delete(allergieId);
        }
    }
}
