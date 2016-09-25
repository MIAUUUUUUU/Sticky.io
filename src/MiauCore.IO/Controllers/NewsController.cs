using MiauCore.IO.Domain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MiauCore.IO.Controllers
{
    [DisableCors]
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private NewsService _newsService;
        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var news = await _newsService.ListNews();
            return Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var news = await _newsService.GetNews(id);

            if (news != null && news.IsActive)
            {                
                return Ok(news);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
