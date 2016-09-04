using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Domain.Infraestrutura;
using MiauCore.IO.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class NewsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NewsViewModel vm)
        {
            var news = vm.News;
            news.WriteDate = DateTime.Now;
            news.LastRevisionDate = DateTime.Now;

            var repo = _unitOfWork.CreateRepository<News>();
            repo.Add(vm.News);

            return View();
        }
    }
}
