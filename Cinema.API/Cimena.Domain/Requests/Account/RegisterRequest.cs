using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Requests.Account
{
   public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
