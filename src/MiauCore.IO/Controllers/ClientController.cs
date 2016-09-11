using MiauCore.IO.Data;
using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiauCore.IO.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private GenericRepository<Client> _repoClient;
        private ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Post([FromBody]Client client)
        {
            _repoClient = new GenericRepository<Client>(_context);
            _repoClient.Add(client);
        }
    }
}
