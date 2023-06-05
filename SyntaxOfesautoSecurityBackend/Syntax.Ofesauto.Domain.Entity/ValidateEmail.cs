using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ VALIDATE EMAIL DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class ValidateEmail
    {

        public int UserId { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

    }
    #endregion

}
