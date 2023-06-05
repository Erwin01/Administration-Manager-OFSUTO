using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ CITY ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class CityByRegionByCountry
    {

        public int CityId { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }

    }
    #endregion

}
