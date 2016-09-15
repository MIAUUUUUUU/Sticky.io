using MiauCore.IO.Domain.Infra;
using MiauCore.IO.Models;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController<Product>
    {
        public ProductController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}