using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Domain.Models;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    public class NewsController : BaseAdminController<News>
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;

        public NewsController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
            :base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public override async Task<IActionResult> Index()
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();
            var news = await newsRepo.List();
            return View(news);
        }

        [HttpGet]
        public override IActionResult Add()
        {
            var productRepo = _unitOfWork.CreateRepository<Product>();
            var products = productRepo.List();
            return View(products);
        }

        [HttpPost]
        public override async Task<IActionResult> Add(News news)
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();

            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            
            news.PublishedBy = user.UserName;
            news.WriteDate = DateTime.Now;
            news.LastRevisionDate = DateTime.Now;

            newsRepo.Add(news);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public override async Task<IActionResult> Update(int id)
        {
            var newsRepo = _unitOfWork.CreateRepository<News>();
            var productRepo = _unitOfWork.CreateRepository<Product>();

            var news = await newsRepo.GetById(id);

            if (news == null)
                return RedirectToAction("Index");

            var viewModel = new NewsViewModel()
            {
                Products = await productRepo.List(),
                News = news
            };

            return View(viewModel);
        }

        [HttpPost]
        public override async Task<bool> Update(News news)
        {
            try
            {
                var newsRepo = _unitOfWork.CreateRepository<News>();
                
                news.LastRevisionDate = DateTime.Now;
                newsRepo.Update(news);

                await _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var newsRepo = _unitOfWork.CreateRepository<News>();
                newsRepo.Delete(id);

                await _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
