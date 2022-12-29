using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Allergies.Service
{
    public interface IAllergieService : ICrudService<Allergie>
    {
    }
}
