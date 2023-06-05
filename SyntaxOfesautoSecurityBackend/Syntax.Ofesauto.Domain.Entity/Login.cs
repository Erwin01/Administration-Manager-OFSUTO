using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ LOGIN ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class Login
    {

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    #endregion
}
