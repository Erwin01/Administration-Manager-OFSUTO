using System;
using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ USER DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    /// 
    public class UserDTO
    {

        public int UserId { get; set; }

        public int UserTypeId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "The field is required")]
        public string UserName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "The field is mandatory")]
        public string LastName { get; set; }

        [Display(Name = "Document Type")]
        [Required(ErrorMessage = "The field is mandatory")]
        public int DocumentTypeId { get; set; }

        [Display(Name = "Document Number")]
        [Required(ErrorMessage = "The field is mandatory")]
        public string UserIdNumber { get; set; }

        [Display(Name = "Address")]
        public string UserAddress { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "The field is mandatory")]
        public int CountryId { get; set; }

        [Display(Name = "Region")]
        public int? RegionId { get; set; }

        [Display(Name = "City")]
        public int? CityId { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Phone Code")]
        [Required(ErrorMessage = "The field is mandatory")]
        public int PhoneCodeId { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "The field is mandatory")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "The field is mandatory")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field is mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Updated Date")]
        [DataType(DataType.DateTime)]
       
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

    }
}
#endregion
