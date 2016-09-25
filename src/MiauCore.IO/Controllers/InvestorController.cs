using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MiauCore.IO.Controllers
{
    [Route("api/[controller]")]
    public class InvestorController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public InvestorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Investor investor)
        {
            var repoInvestor = _unitOfWork.CreateRepository<Investor>();
            repoInvestor.Add(investor);
            await _unitOfWork.SaveChanges();

            return Ok();
        }
    }
}
