using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syntax.Ofesauto.Security.Application.Interface;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CityController : ControllerBase
    {

        private readonly IUserApplication _userApplication;

        #region [ CONSTRUCTOR ]
        public CityController(IUserApplication userApplication)
        {
            _userApplication = userApplication;

        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> GetAllCityAsync()
        {

            var response = await _userApplication.GetAllCityAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }


        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCityByIdAsync(string cityId)
        {
            if (string.IsNullOrEmpty(cityId))
            {
                return BadRequest("Fields cannot be empty");

            }
            var response = await _userApplication.GetCityByIdAsync(cityId);

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
        public async Task<IActionResult> GetCityByRegionByCountryAsync(string countryId, string regionId)
        {

            if (string.IsNullOrEmpty(countryId) || string.IsNullOrEmpty(regionId))
            {
                return BadRequest("Fields cannot be empty");

            }


            var response = await _userApplication.GetCityByRegionByCountryAsync(countryId, regionId);

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
