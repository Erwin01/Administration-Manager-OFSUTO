using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ CHANGE USER PASSWORD DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class ChangeUserPasswordDTO
    {



        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field is mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    #endregion

}
