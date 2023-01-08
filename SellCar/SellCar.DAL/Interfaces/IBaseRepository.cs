﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);

        IQueryable<T> GetAll();

        Task Delete(T entity);

        Task<T> Update(T entity);
    }
}
