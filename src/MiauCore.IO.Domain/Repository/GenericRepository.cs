using MiauCore.IO.Domain.Data;
using MiauCore.IO.Domain.Infraestrutura;
using MiauCore.IO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

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
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> List()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
