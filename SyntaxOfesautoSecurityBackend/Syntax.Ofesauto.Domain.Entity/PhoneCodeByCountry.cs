using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ PHONE CODE BY COUNTRY ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class PhoneCodeByCountry
    {

        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Phone Code")]
        public string PhoneCodeId { get; set; }

    }
    #endregion

}
