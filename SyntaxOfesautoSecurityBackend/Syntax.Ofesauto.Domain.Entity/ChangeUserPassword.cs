using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ CHANGE PASSWORD ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class ChangeUserPassword
    {
        public int UserId { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "The field is mandatory")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field is mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    #endregion

}
