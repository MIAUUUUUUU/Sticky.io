using MiauCore.IO.Data;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiauCore.IO.Domain.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IGenericEntity
    {
        ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async void Delete(int id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<T>> List()
        {
            return await _dbSet.ToListAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
