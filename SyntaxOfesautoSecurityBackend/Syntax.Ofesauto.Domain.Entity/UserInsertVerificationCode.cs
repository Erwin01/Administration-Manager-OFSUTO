using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ USER INSERT VERIFICATION CODE ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class UserInsertVerificationCode
    {

        public int UserId { get; set; }

        [Display(Name = "Verification Code")]
        [StringLength(5)]
        public string VerificationCode { get; set; }

    }
    #endregion

}
