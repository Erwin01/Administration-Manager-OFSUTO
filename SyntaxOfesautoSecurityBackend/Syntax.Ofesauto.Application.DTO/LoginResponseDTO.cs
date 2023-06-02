using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Syntax.Ofesauto.Security.Application.DTO
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeDescription { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
