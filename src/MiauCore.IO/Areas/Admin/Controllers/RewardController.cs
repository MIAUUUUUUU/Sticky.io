using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Data;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class RewardController : Controller
    {
        private GenericRepository<Reward> _rewardRepo;
        private GenericRepository<Product> _productRepo;
        private ApplicationDbContext _context;

        public RewardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            _rewardRepo = new GenericRepository<Reward>(_context);
            var rewards = await _rewardRepo.List();
            return View(rewards);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            _productRepo = new GenericRepository<Product>(_context);
            var products = await _productRepo.List();

            var viewModel = new RewardViewModel()
            {
                ProductList = new SelectList(products)
            };

            return View(products);
        }

        [HttpPost]
        public IActionResult Add(RewardViewModel viewModel)
        {
            var product = (Product)viewModel.ProductList.SelectedValue;
            var reward = viewModel.Reward;
            reward.ProductId = product.Id;
            reward.Product = product;
                        
            _rewardRepo = new GenericRepository<Reward>(_context);
            _rewardRepo.Add(reward);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            _rewardRepo = new GenericRepository<Reward>(_context);
            var reward = await _rewardRepo.GetById(id);

            if (reward == null)
                return RedirectToAction("Index");

            return View(reward);
        }

        [HttpPost]
        public bool Update(Reward reward)
        {
            try
            {
                _rewardRepo = new GenericRepository<Reward>(_context);
                _rewardRepo.Update(reward);

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
                _rewardRepo = new GenericRepository<Reward>(_context);
                _rewardRepo.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
