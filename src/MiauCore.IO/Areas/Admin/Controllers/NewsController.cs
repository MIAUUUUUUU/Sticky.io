using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Data;
using MiauCore.IO.Domain.Models;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class NewsController : Controller
    {
        private GenericRepository<News> _newsRepo;
        private GenericRepository<Product> _productRepo;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public NewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsRepo.List();
            return View(news);
        }

        [HttpGet]
        public IActionResult Add()
        {
            _productRepo = new GenericRepository<Product>(_context);
            var products = _productRepo.List();
            return View(products);
        }

        [HttpPost]
        public IActionResult Add(NewsViewModel vm)
        {
            _newsRepo = new GenericRepository<News>(_context);

            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var news = vm.News;
            news.PublishedBy = user;
            news.WriteDate = DateTime.Now;
            news.LastRevisionDate = DateTime.Now;

            _newsRepo.Add(news);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var news = await _newsRepo.GetById(id);

            if (news == null)
                return RedirectToAction("Index");

            _newsRepo = new GenericRepository<News>(_context);

            var viewModel = new NewsViewModel()
            {
                Products = await _productRepo.List(),
                News = news
            };

            return View(viewModel);
        }

        [HttpPost]
        public bool Update(NewsViewModel vm)
        {
            try
            {
                _newsRepo = new GenericRepository<News>(_context);
                var news = vm.News;
                news.LastRevisionDate = DateTime.Now;
                _newsRepo.Update(news);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                _newsRepo = new GenericRepository<News>(_context);
                _newsRepo.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
