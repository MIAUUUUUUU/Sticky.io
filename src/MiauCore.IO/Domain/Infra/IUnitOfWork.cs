using MiauCore.IO.Models;

namespace MiauCore.IO.Domain.Infra
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> CreateRepository<T>() where T : class, IGenericEntity;
    }
}
