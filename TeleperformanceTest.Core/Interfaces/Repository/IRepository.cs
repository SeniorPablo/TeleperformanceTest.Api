﻿using TeleperformanceTest.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeleperformanceTest.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int entity);
    }
}
