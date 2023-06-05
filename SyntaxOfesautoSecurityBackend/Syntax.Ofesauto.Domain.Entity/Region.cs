using System;
using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ REGION ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class Region
    {

        public int RegionId { get; set; }

        [Display(Name = "Region Name")]
        public string RegionName { get; set; }

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
