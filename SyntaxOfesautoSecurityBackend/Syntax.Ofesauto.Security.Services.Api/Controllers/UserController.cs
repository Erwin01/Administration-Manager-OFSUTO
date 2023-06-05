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
    public class UserController : ControllerBase
    {


        /// <summary>
        /// Globel variables
        /// </summary>
        private readonly IUserApplication _userApplication;
        private readonly IEmailSender _emailSender;

        #region [ CONSTRUCTOR ]
        public UserController(IUserApplication userApplication, IEmailSender emailSender, IOptions<AppSettings> options)
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



            var response = await _userApplication.InsertAsync(userDTO);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.UpdateAsync(userDTO);

            if (response.IsSuccess)
            {

                var message = new Message(new string[] { $"{ userDTO.Email }" }, "Change of password", "Your password change was succesful.</br><p>Your new password: " + $"<strong>{ userDTO.Password }</strong></p>" + "<hr></br><p>Login in the web site: https://www.ofesauto.es/</p></br></br><h3>&#169; 2021 Ofesauto. All right reserved.</h3>", null);
                _emailSender.SendEmail(message);

                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.DeleteAsync(userId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("User has already been deleted!");
            }
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(string userId)
        {

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.GetByIdAsync(userId);

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

            var response = await _userApplication.GetAllAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
        #endregion

    }
}
