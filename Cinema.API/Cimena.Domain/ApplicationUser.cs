using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain
{
   public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; }
    }
}
