using MiauCore.IO.Data;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Domain.Services
{
    public class NewsService
    {
        private ApplicationDbContext _context;

        public NewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<News> GetNews(int id)
        {
            var news = await _context.News
                .Include(product => product.Product)
                .FirstOrDefaultAsync(n => n.Id == id);

            return news;
        }

        public async Task<ICollection<News>> ListNews()
        {
            var news = await _context.News
                .Include(product => product.Product)
                .Where(n => n.IsActive)
                .ToListAsync();

            return news.OrderByDescending(x => x.WriteDate).ToList();
        }
    }
}
