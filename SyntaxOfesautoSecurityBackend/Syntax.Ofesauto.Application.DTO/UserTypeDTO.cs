using System;
using System.Collections.Generic;
using System.Text;

namespace Syntax.Ofesauto.Security.Application.DTO
{
    public class UserTypeDTO
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
