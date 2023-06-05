using Microsoft.AspNetCore.Mvc;
using Syntax.Ofesauto.Security.Application.Interface;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RegionController : ControllerBase
    {


        private readonly IUserApplication _userApplication;

        #region [ CONSTRUCTOR ]
        public RegionController(IUserApplication userApplication)
        {
            _userApplication = userApplication;

        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> GetAllRegionAsync()
        {

            var response = await _userApplication.GetAllRegionAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }


        [HttpGet("{regionId}")]
        public async Task<IActionResult> GetRegionByIdAsync(string regionId)
        {
            if (string.IsNullOrEmpty(regionId))
            {
                return BadRequest("Fields cannot be empty");

            }
            var response = await _userApplication.GetRegionByIdAsync(regionId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetRegionsByCountryIdAsync(string countryId)
        {

            if (string.IsNullOrEmpty(countryId))
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.GetCountryByRegionIdAsync(countryId);


            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Data no exists!");

            }

        }

    }
}
