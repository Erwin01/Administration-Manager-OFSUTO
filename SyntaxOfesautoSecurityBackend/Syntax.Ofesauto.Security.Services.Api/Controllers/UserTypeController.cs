using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Application.Interface;
using Syntax.Ofesauto.Security.Services.Api.Email;
using Syntax.Ofesauto.Security.Services.Api.Helpers;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserTypeController : ControllerBase
    {


        /// <summary>
        /// Globel variables
        /// </summary>
        private readonly IUserTypeApplicationEF _userApplication;

        #region [ CONSTRUCTOR ]
        public UserTypeController(IUserTypeApplicationEF userApplication)
        {
            _userApplication = userApplication;
        }
        #endregion


        #region [ ASYNCHRONOUS METHODS ]
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] UserTypeDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Fields cannot be empty");

            }
            var response = await _userApplication.Add(userDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UserTypeDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    return BadRequest("Fields cannot be empty");

                }
                var response = await _userApplication.Update(userDTO, userDTO.UserTypeId);
                if (response.IsSuccess)
                {                 
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            if (string.IsNullOrEmpty(Id.ToString()))
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.Delete(Id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int userId)
        {

            if (string.IsNullOrEmpty(userId.ToString()))
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.GetById(userId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("User not exits!");
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var response = await _userApplication.GetAll();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }
        #endregion

    }
}
