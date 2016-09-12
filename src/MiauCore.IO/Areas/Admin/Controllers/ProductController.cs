using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var productRepo = _unitOfWork.CreateRepository<Product>();
            var products = await productRepo.List();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var productRepo = _unitOfWork.CreateRepository<Product>();
            productRepo.Add(product);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var productRepo = _unitOfWork.CreateRepository<Product>();
            var product = await productRepo.GetById(id);

            if (product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        [HttpPost]
        public async Task<bool> Update(Product product)
        {
            try
            {
                var productRepo = _unitOfWork.CreateRepository<Product>();
                productRepo.Update(product);

                await _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public async Task<bool> Delete(int id)
        {
            try
            {
                var productRepo = _unitOfWork.CreateRepository<Product>();
                productRepo.Delete(id);

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
