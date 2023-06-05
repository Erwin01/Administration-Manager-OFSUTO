using Microsoft.AspNetCore.Mvc;
using Syntax.Ofesauto.Security.Application.Interface;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CountryController : ControllerBase
    {

        private readonly IUserApplication _userApplication;

        #region [ CONSTRUCTOR ]
        public CountryController(IUserApplication userApplication)
        {
            _userApplication = userApplication;

        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> GetAllCountryAsync()
        {

            var response = await _userApplication.GetAllCountryAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }



        [HttpGet]
        public async Task<IActionResult> GetAllPhoneCodeByCountryIdAsync()
        {

            var response = await _userApplication.GetAllPhoneCodeByCountryIdAsync();

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
