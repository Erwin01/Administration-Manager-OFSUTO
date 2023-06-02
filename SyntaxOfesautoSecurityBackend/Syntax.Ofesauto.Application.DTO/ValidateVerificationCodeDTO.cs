using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ VALIDATE VERIFICATION CODE DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class ValidateVerificationCodeDTO
    {

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "The field is mandatory")]
        public string Email { get; set; }


        [Display(Name = "Verification Code")]
        [StringLength(5, ErrorMessage = "The Verification Code field must be a number with a maximum length of 5.")]
        [Required(ErrorMessage = "Verification Code is required")]
        public string CodeVerification { get; set; }

    }
    #endregion

}
