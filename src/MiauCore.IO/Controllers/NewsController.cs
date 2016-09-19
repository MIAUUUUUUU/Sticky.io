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
        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<ICollection<News>> Get()
        {
            var news = await _newsService.ListNews();

            return news;
        }

        [HttpGet("{id}")]
        public async Task<News> Get(int id)
        {
            var news = await _newsService.GetNews(id);

            return news;
        }
    }
}
