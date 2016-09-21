using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Domain.Models;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class NewsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;

        public NewsController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();
            var news = await newsRepo.List();
            return View(news);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var productRepo = _unitOfWork.CreateRepository<Product>();
            var products = await productRepo.List();
            var viewModel = new NewsViewModel
            {
                Products = products
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewsViewModel viewModel)
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();
            var news = viewModel.News;
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            
            news.PublishedBy = user.UserName;
            news.WriteDate = DateTime.Now;
            news.LastRevisionDate = DateTime.Now;
            news.ProductId = viewModel.ProductId;
            newsRepo.Add(news);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "News");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();
            var productRepo = _unitOfWork.CreateRepository<Product>();

            var news = await newsRepo.GetById(id);

            if (news == null)
                return RedirectToAction("Index", "News");

            var viewModel = new NewsViewModel()
            {
                Products = await productRepo.List(),
                News = news
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(NewsViewModel viewModel)
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();
            var news = viewModel.News;
            news.LastRevisionDate = DateTime.Now;
            news.ProductId = viewModel.ProductId;
            newsRepo.Update(news);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "News");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();
            newsRepo.Delete(id);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "News");
        }
    }
}
