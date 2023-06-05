using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ VALIDATE VERIFICATION ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class ValidateVerificationCode
    {

        [Display(Name = "Verification Code")]
        [StringLength(5)]
        [Required(ErrorMessage = "Verification Code is required")]
        public string CodeVerification { get; set; }

    }
    #endregion

}
