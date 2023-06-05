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
    public class UserAdminController : ControllerBase
    {


        /// <summary>
        /// Globel variables
        /// </summary>
        private readonly IUserApplicationEF _userApplication;
        private readonly IEmailSender _emailSender;

        #region [ CONSTRUCTOR ]
        public UserAdminController(IUserApplicationEF userApplication, IEmailSender emailSender, IOptions<AppSettings> options)
        {
            _userApplication = userApplication;
            _emailSender = emailSender;
        }
        #endregion


        #region [ ASYNCHRONOUS METHODS ]
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] UserDTO userDTO)
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
        public async Task<IActionResult> UpdateAsync([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    return BadRequest("Fields cannot be empty");

                }
                var response = await _userApplication.Update(userDTO, userDTO.UserId);
                if (response.IsSuccess)
                {

                    var message = new Message(new string[] { $"{ userDTO.Email }" }, "Change of password", "Your password change was succesful.</br><p>Your new password: " + $"<strong>{ userDTO.Password }</strong></p>" + "<hr></br><p>Login in the web site: https://www.ofesauto.es/</p></br></br><h3>&#169; 2021 Ofesauto. All right reserved.</h3>", null);
                    _emailSender.SendEmail(message);

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


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            if (string.IsNullOrEmpty(userId.ToString()))
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.Delete(userId);

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
