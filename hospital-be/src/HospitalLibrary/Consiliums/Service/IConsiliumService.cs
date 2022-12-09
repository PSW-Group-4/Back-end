using HospitalLibrary.Consiliums.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Consiliums.Service
{
    public interface IConsiliumService
    {
        IEnumerable<Consilium> GetAll();
        Consilium GetById(Guid id);
        IEnumerable<Consilium> GetDoctorsConsiliums(Guid DoctorId);
        Consilium Create(ConsiliumRequest consiliumRequest);
    }
}
