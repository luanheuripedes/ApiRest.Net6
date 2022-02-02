﻿using Domain.Entities;

namespace Infrastructure.Interfaces
{


    public interface IBaseRepository<T> where T : Base
     {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T> Remove(long id);
        Task<T> Get(long id);
        Task<List<T>> GetAll();
     }
}
