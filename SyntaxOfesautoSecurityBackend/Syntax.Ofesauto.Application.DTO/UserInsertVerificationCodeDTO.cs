using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ USER INSERT VERIFICATION CODE DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class UserInsertVerificationCodeDTO
    {

        public int UserId { get; set; }

        [Display(Name = "Verification Code")]
        [StringLength(5, ErrorMessage = "Description Max Length is 5 numbers")]
        public string VerificationCode { get; set; }

    }
    #endregion

}
