using MiauCore.IO.Data;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiauCore.IO.Controllers
{
    [Route("api/[controller]")]
    public class InvestorController : Controller
    {
        private GenericRepository<Investor> _repoInvestor;
        private ApplicationDbContext _context;

        public InvestorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Post([FromBody]Investor investor)
        {
            _repoInvestor = new GenericRepository<Investor>(_context);
            _repoInvestor.Add(investor);
        }
    }
}
