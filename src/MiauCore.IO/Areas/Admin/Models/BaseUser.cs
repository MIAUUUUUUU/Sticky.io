namespace MiauCore.IO.Areas.Admin.Models
{
    public abstract class BaseUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
