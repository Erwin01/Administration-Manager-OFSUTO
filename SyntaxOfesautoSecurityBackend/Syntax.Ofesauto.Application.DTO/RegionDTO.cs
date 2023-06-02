using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ REGION DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class RegionDTO
    {

        public int RegionId { get; set; }

        [Display(Name = "Region Name")]
        public string RegionName { get; set; }

    }
    #endregion

}
