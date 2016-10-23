using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Data;
using MiauCore.IO.Models;
using Microsoft.EntityFrameworkCore;
using MiauCore.IO.Models.ManyToMany;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MiauCore.IO.Controllers
{
    [Route("/[controller]/[action]")]
    public class RewardController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private ApplicationDbContext _context;

        public RewardController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Rewards).ToList();
            products = products.Where(p => p.Rewards != null && p.Rewards.Count() > 0).ToList();

            return View(products);
        }

        public IActionResult Donate(int id)
        {
            var rewards = _context.Rewards.Include(r => r.Product).Where(r => r.ProductId == id);
            var viewModel = new RewardViewModel()
            {
                Rewards = rewards
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Donate(RewardViewModel viewModel)
        {
            var count = _context.Rewards.Count(c => c.Id == viewModel.RewardId);
            var quantity = _context.Rewards.FirstOrDefault(c => c.Id == viewModel.RewardId).Quantity;

            if (quantity > count)
            {
                viewModel.Investor.InvestorReward.Add(new InvestorReward { InvestorId = viewModel.Investor.Id, RewardId = viewModel.RewardId });
                var repo = _unitOfWork.CreateRepository<Investor>();
                repo.Add(viewModel.Investor);
                _unitOfWork.SaveChanges();
                count++;
            }

            return Redirect("Index");
        }
    }

    public class RewardViewModel
    {
        public Investor Investor { get; set;}
        public IEnumerable<Reward> Rewards { get; set; }
        public int RewardId { get; set; }
        public int HowMuch { get; set; }
    }
}
