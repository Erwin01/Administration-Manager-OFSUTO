using System;
using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ CITY ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class City
    {
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }

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
