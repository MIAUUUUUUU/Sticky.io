using MiauCore.IO.Data;
using MiauCore.IO.Domain.Services;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiauCore.IO.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private NewsService _newsService;
        private ApplicationDbContext _context;
        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ICollection<News>> Get()
        {
            _newsService = new NewsService(_context);

            var news = await _newsService.ListNews();

            return news;
        }

        [HttpGet("{id}")]
        public async Task<News> Get(int id)
        {
            _newsService = new NewsService(_context);

            var news = await _newsService.GetNews(id);

            return news;
        }
    }
}
