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
        private IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async void Post([FromBody]Client client)
        {
            var repoClient = _unitOfWork.CreateRepository<Client>();
            repoClient.Add(client);
            await _unitOfWork.SaveChanges();
        }
    }
}
