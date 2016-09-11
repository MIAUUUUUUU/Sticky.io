using MiauCore.IO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Domain.Infra
{
    public interface IGenericRepository<T> where T : IGenericEntity
    {
        void Add(T entity);
        Task<IList<T>> List();
        void Delete(int id);
        Task<T> GetById(int id);
        void Update(T entity);
    }
}
