using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ CITY BY REGION BY COUNTRY DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class CityByRegionByCountryDTO
    {

        public int CityId { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }


    }
    #endregion

}
