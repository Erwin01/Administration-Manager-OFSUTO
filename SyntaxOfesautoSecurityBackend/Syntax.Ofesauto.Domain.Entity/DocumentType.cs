using System;
using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Domain.Entity
{

    #region [ DOCUMENT TYPE ENTITY ]
    /// <summary>
    /// Method that allows placing the attributes of the entity
    /// </summary>
    public class DocumentType
    {

        public int DocumentTypeId { get; set; }

        [Display(Name = "Document Name")]
        public string DocumentTypeName { get; set; }

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
