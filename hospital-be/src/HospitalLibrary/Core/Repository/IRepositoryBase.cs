using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}