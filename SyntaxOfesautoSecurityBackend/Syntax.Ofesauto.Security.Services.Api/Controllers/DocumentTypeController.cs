using Microsoft.AspNetCore.Mvc;
using Syntax.Ofesauto.Security.Application.Interface;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DocumentTypeController : ControllerBase
    {


        private readonly IUserApplication _userApplication;

        #region [ CONSTRUCTOR ]
        public DocumentTypeController(IUserApplication userApplication)
        {
            _userApplication = userApplication;

        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> GetAllDocumentTypeAsync()
        {

            var response = await _userApplication.GetAllDocumentTypeAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }

    }
}
