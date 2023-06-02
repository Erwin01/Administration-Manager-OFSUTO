using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ VALIDATE EMAIL DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class ValidateEmailUserDTO
    {

        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Verification Code")]
        public string VerificationCode { get; set; }

    }
    #endregion

}
