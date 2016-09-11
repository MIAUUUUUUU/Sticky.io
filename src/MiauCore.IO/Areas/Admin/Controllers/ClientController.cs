using MiauCore.IO.Data;
using MiauCore.IO.Domain.Repository;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize]
    public class ClientController : Controller
    {
        private GenericRepository<Client> _clientRepo;
        private ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            _clientRepo = new GenericRepository<Client>(_context);
            var clients = await _clientRepo.List();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Client client)
        {
            _clientRepo = new GenericRepository<Client>(_context);
            _clientRepo.Add(client);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            _clientRepo = new GenericRepository<Client>(_context);
            var client = await _clientRepo.GetById(id);

            if (client == null)
                return RedirectToAction("Index");

            return View(client);
        }

        [HttpPost]
        public bool Update(Client client)
        {
            try
            {
                _clientRepo = new GenericRepository<Client>(_context);
                _clientRepo.Update(client);

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
                _clientRepo = new GenericRepository<Client>(_context);
                _clientRepo.Delete(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
