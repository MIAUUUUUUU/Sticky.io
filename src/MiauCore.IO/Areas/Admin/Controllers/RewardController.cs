using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Data;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class RewardController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private ApplicationDbContext _context;
        public RewardController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        
        public async Task<IActionResult> Index(RewardAdminViewModel viewModel)
        {
            var reward = await _context.Rewards.Include(r => r.Product).ToListAsync();
            if (viewModel.Filter != null)
            {
                var filter = viewModel.Filter;
                reward = reward.Where(c => c.Id == filter.Id || c.Name == filter.Name || c.Price == filter.Price || c.Quantity == filter.Quantity || c.Prize == filter.Prize).ToList();
            }

            viewModel.Rewards = reward;
            return View(reward);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var productRepo = _unitOfWork.CreateRepository<Product>();
            var products = await productRepo.List();
            var viewModel = new RewardViewModel
            {
                Products = products
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RewardViewModel viewModel)
        {
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            var reward = viewModel.Reward;
            
            reward.ProductId = viewModel.ProductId;
            rewardRepo.Add(reward);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "reward");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            var productRepo = _unitOfWork.CreateRepository<Product>();

            var reward = await rewardRepo.GetById(id);

            if (reward == null)
                return RedirectToAction("Index", "Reward");

            var viewModel = new RewardViewModel()
            {
                Products = await productRepo.List(),
                Reward = reward
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RewardViewModel viewModel)
        {
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            var reward = viewModel.Reward;
            rewardRepo.Update(reward);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Reward");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            rewardRepo.Delete(id);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Reward");
        }
    }

    public class RewardAdminViewModel
    {
        public IEnumerable<Reward> Rewards { get; set; }
        public Reward Filter { get; set; }
    }
}
