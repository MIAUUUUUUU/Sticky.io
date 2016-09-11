using MiauCore.IO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace MiauCore.IO.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<News> PublishedNews { get; set; }
    }
}
