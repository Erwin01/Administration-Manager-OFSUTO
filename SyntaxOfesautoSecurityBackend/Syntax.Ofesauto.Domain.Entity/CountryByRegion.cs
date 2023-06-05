using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ COUNTRY BY REGION ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class CountryByRegion
    {

        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Phone Code")]
        public int PhoneCodeId { get; set; }

        public int RegionId { get; set; }

        [Display(Name = "Region Name")]
        [StringLength(80)]
        public string RegionName { get; set; }

    }
    #endregion

}