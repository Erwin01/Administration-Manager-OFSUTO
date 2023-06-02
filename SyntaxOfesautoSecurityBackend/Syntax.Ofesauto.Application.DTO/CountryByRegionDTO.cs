using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ COUNTRY BY REGION DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class CountryByRegionDTO
    {

        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Phone Code")]
        public int PhoneCodeId { get; set; }

        public int RegionId { get; set; }

        [Display(Name = "Region Name")]
        public string RegionName { get; set; }

    }
    #endregion

}