using MiauCore.IO.Models;

namespace MiauCore.IO.Areas.Admin.Models
{
    public class User : IGenericEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}