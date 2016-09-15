using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    public class RewardController : BaseAdminController<Reward>
    {
        public RewardController(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }
    }
}
