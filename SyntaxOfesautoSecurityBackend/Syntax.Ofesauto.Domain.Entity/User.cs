using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ USER ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class User
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
        [Column("CitytId")]
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
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field is mandatory")]
        public string Password { get; set; }

        [Display(Name = "Verification Code")]
        public string VerificationCode { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
       // [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        [DataType(DataType.DateTime)]
      //  [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime? UpdatedDate { get; set; }

    }
    #endregion

}