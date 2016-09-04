using MiauCore.IO.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.ViewModels
{
    public class LoginViewModel
    {

        public LoginViewModel()
        {
            IdentityErrors = new List<IdentityError>();
        }
        public User User { get; set; }

        public IEnumerable<IdentityError> IdentityErrors { get; set; }
    }
}
