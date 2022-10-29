using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.BuildingManagmentMap.Service.Interfaces
{
    public interface ICrudService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Create(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}
