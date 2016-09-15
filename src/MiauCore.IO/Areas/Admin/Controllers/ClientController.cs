using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    public class ClientController : BaseAdminController<Client>
    {
        public ClientController(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }        
    }
}
