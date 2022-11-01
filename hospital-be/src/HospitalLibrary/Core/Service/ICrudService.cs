﻿using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface ICrudService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Create(T entity);
        T Update(T entity);
        void Delete(Guid entityId);
    }
}
