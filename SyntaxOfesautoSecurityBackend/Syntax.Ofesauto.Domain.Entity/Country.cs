using System;
using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ COUNTRY ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class Country
    {

        [Display(Name = "Country Id")]
        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Phone Code")]
        public int PhoneCodeId { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime UpdatedDate { get; set; }

    }
    #endregion

}
