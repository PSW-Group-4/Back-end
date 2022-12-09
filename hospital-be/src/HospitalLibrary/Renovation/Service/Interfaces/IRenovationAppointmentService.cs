using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.Renovation.Service.Interfaces
{
    public interface IRenovationAppointmentService : ICrudService<RenovationAppointment>
    {
        public void CreateRenovation(RenovationDataDto data);
    }
}