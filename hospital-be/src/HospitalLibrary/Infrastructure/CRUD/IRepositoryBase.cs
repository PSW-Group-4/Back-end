using System;
using System.Collections.Generic;

namespace HospitalLibrary.Infrastructure.CRUD
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Create(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}