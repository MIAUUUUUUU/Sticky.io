using MiauCore.IO.Domain.Models;
using System.Collections.Generic;

namespace MiauCore.IO.Domain.Infraestrutura
{
    public interface IGenericRepository<T> where T : IGenericEntity
    {
        void Add(T entity);
        IList<T> List();
        void Delete(int id);
        T GetById(int id);
        void Update(T entity);
    }
}
