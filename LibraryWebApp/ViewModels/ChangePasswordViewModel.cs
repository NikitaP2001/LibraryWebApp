using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
