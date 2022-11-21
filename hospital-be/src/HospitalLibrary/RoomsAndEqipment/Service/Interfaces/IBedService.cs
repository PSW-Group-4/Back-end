using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Service.Interfaces
{
    public interface IBedService
    {
        IEnumerable<Bed> GetAll();
        Bed GetById(Guid id);
        Bed Create(Bed bed);
        Bed Update(Bed bed);
        void Delete(Guid bedId);
    }
}
