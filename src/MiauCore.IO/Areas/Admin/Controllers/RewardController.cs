using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    public class RewardController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public RewardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IActionResult> Index()
        {
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            var reward = await rewardRepo.List();
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
}
