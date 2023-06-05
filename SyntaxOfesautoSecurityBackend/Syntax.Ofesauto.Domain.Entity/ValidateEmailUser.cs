using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ VALIDATE EMAIL ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class ValidateEmailUser
    {

        [Display(Name = "Email")]
        [StringLength(80)]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Verification Code")]
        public string VerificationCode { get; set; }

    }
    #endregion

}
