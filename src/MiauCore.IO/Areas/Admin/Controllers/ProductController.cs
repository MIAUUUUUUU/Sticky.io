using MiauCore.IO.Data;
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
        private GenericRepository<Product> _productRepo;
        private ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            _productRepo = new GenericRepository<Product>(_context);
            var products = await _productRepo.List();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productRepo = new GenericRepository<Product>(_context);
            _productRepo.Add(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            _productRepo = new GenericRepository<Product>(_context);
            var product = await _productRepo.GetById(id);

            if (product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        [HttpPost]
        public bool Update(Product product)
        {
            try
            {
                _productRepo = new GenericRepository<Product>(_context);
                _productRepo.Update(product);

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
                _productRepo = new GenericRepository<Product>(_context);
                _productRepo.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
