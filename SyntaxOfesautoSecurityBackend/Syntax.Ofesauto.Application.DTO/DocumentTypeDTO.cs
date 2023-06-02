using System.ComponentModel.DataAnnotations;

namespace Syntax.Ofesauto.Security.Application.DTO
{

    #region [ DOCUMENT TYPE DTO ]
    /// <summary>
    /// Method that allows placing only the attributes that are going to be exposed
    /// </summary>
    public class DocumentTypeDTO
    {

        public int DocumentTypeId { get; set; }

        [Display(Name = "Document Name")]
        public string DocumentTypeName { get; set; }

    }
    #endregion

}
