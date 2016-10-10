using MiauCore.IO.Areas.Admin.Models;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    public class InvestorController : Controller
    {
        IUnitOfWork _unitOfWork;

        public InvestorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index(InvestorViewModel viewModel)
        {
            var investorRepo = _unitOfWork.CreateRepository<Investor>();
            var investors = await investorRepo.List();

            if (viewModel.Filter != null)
            {
                var filter = viewModel.Filter;
                investors = investors.Where(c => c.Id == filter.Id || c.Company == filter.Company || c.Telephone == filter.Telephone || c.Address == filter.Address || c.Email == filter.Email || c.NERC == filter.NERC).ToList();
            }

            viewModel.Investors = investors;

            return View(viewModel);
        }
    }
}