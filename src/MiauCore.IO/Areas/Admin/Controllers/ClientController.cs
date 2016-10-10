using MiauCore.IO.Areas.Admin.Models;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ClientController : Controller
    {
        IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ClientViewModel viewModel)
        {
            var clientRepo = _unitOfWork.CreateRepository<Client>();
            var clients = await clientRepo.List();

            if (viewModel.Filter != null)
            {
                var filter = viewModel.Filter;
                clients = clients.Where(c => c.Id == filter.Id || c.Name == filter.Name || c.Telephone == filter.Telephone || c.TaxId == filter.TaxId || c.Email == filter.Email).ToList();
            }

            viewModel.Clients = clients;

            return View(viewModel);
        }
    }
}
