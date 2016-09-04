using MiauCore.IO.Domain.Data;
using MiauCore.IO.Domain.Infraestrutura;
using MiauCore.IO.Domain.Models;
using MiauCore.IO.Domain.Repository;

namespace MiauCore.IO.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> CreateRepository<T>() where T : class, IGenericEntity
        {
            return new GenericRepository<T>(_context);
        }
    }
}
