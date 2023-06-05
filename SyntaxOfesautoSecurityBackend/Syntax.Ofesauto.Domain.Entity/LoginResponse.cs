using System;
using System.Collections.Generic;
using System.Text;

namespace Syntax.Ofesauto.Security.Domain.Entity
{
    public class LoginResponse
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
