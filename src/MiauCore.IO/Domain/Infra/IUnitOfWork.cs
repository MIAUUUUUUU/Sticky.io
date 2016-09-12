using MiauCore.IO.Models;
using System.Threading.Tasks;

namespace MiauCore.IO.Domain.Infra
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> CreateRepository<T>() where T : class, IGenericEntity;
        Task SaveChanges();
    }
}
