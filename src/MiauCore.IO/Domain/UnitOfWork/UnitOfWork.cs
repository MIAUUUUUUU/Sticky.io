using MiauCore.IO.Data;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using System.Threading.Tasks;

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

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
