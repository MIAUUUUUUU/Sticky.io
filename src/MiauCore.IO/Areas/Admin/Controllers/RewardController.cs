using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Data;
using MiauCore.IO.Domain.Infra;
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
        private IUnitOfWork _unitOfWork;
        private ApplicationDbContext _context;

        public RewardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            var rewards = await rewardRepo.List();
            return View(rewards);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var productRepo = _unitOfWork.CreateRepository<Product>();
            var products = await productRepo.List();

            var viewModel = new RewardViewModel()
            {
                ProductList = new SelectList(products)
            };

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RewardViewModel viewModel)
        {
            var product = (Product)viewModel.ProductList.SelectedValue;
            var reward = viewModel.Reward;
            reward.ProductId = product.Id;
            reward.Product = product;
                        
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            rewardRepo.Add(reward);

            await _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var rewardRepo = _unitOfWork.CreateRepository<Reward>();
            var reward = await rewardRepo.GetById(id);

            if (reward == null)
                return RedirectToAction("Index");

            return View(reward);
        }

        [HttpPost]
        public async Task<bool> Update(Reward reward)
        {
            try
            {
                var rewardRepo = _unitOfWork.CreateRepository<Reward>();
                rewardRepo.Update(reward);
                
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
                var rewardRepo = _unitOfWork.CreateRepository<Reward>();
                rewardRepo.Delete(id);
                
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
