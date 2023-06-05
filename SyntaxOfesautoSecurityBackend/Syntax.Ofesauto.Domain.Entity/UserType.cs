using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Syntax.Ofesauto.Security.Domain.Entity
{
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserTypeName { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
