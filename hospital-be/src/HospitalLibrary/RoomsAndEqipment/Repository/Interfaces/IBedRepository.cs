using HospitalLibrary.Core.Repository;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Interfaces
{
    public interface IBedRepository : IRepositoryBase<Bed>
    {
        public Bed FreeBed(Bed bed);
        public Bed CaptureBed(Bed bed);
    }
}
