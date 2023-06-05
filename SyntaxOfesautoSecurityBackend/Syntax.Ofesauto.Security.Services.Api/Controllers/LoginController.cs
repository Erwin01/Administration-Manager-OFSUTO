using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Application.Interface;
using Syntax.Ofesauto.Security.Services.Api.Email;
using Syntax.Ofesauto.Security.Services.Api.Helpers;
using Syntax.Ofesauto.Security.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly IUserApplication _userApplication;
        private readonly AppSettings _appSettings;
        private readonly IEmailSender _emailSender;

        public LoginController(IUserApplication userApplication, IEmailSender emailSender, IOptions<AppSettings> options, IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _userApplication = userApplication;
            _appSettings = options.Value;
            _emailSender = emailSender;
        }


        /// <summary>
        /// Authenticate User Registered
        /// </summary>
        /// <param name="authDTO"></param>
        /// <returns> Token </returns>
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDTO authDTO)
        {
            var response = _userApplication.Authenticate(authDTO);

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    //Create token
                    response.Data.Token = TokenCreation(response);

                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }
            }

            return BadRequest(response.Message);
        }


        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns> User </returns>
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.InsertAsync(userDTO);

            if (response.IsSuccess)
            {


                var message = new Message(new string[] { $"{ userDTO.Email }" }, "Gracias por registrarse", "<span><strong>Bienvenidos al sitio web de OFESAUTO.</strong></span></br></br><hr><p style='color:black;'text-align:center;'>Gracias por registrarse!.</br><div style='color:black;'text-align:center;'>Está a solo un paso de completar su registro, active su cuenta para iniciar a su sitio web y obtener acceso a Ofesauto, OFICINA ESPAÑOLA DE ASEGURADORAS DE AUTOMÓVILES.</br>" + "</div></br></br><a href=http://ofesauto.es/></a></br>&reg; 2021 Ofesauto. All right reserved.</p>", null);

                _emailSender.SendEmail(message);

                return Ok(response);

            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        /// <summary>
        /// Validate Email User If Exists Generate Verification Code and Add into database 
        /// </summary>
        /// <param name="validateEmailDTO"></param>
        /// <returns> Verification Code </returns>
        [HttpPost]
        public IActionResult ValidateEmailUser([FromBody] ValidateEmailUserDTO validateEmailDTO)
        {
            var response = _userApplication.ForgetPassword(validateEmailDTO);

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.VerificationCode = CreateRandomNumbers(response);

                    using var connection = _connectionFactory.GetConnection;

                    var query = "ValidateUserEmail";
                    var parameters = new DynamicParameters();
                    parameters.Add("Email", validateEmailDTO.Email);
                    parameters.Add("VerificationCode", Convert.ToInt32(validateEmailDTO.VerificationCode));

                    var email = connection.QuerySingle<ValidateEmailUserDTO>(query, param: parameters, commandType: CommandType.StoredProcedure);


                    response.Data.VerificationCode = validateEmailDTO.VerificationCode;

                    var message = new Message(new string[] { $"{ validateEmailDTO.Email }" }, "Bienvenido a Ofesauto", "<span><strong>Bienvenido al sitio recuperación contraseña de OFESAUTO.</strong></span></br></br><hr><p style='color:black;'text-align:center;'> </br><div style='color:black;'text-align:center;'>Está a solo un paso de recuperar su contraseña, y poder acceder al sitio web de Ofesauto, OFICINA ESPAÑOLA DE ASEGURADORAS DE AUTOMÓVILES.</br><p>Su código de verificación es: " + $"<strong>{ validateEmailDTO.VerificationCode }</strong></p>" + "</div></br> <a href=http://ofesauto.es/></a></br>&reg; 2021 Ofesauto. All right reserved.</p>", null);

                    _emailSender.SendEmail(message);

                    return Ok(response.Message);

                }
                else
                {
                    return NotFound(response.Message);
                }
            }

            return BadRequest(response.Message);
        }


        /// <summary>
        /// Validate Only Email
        /// </summary>
        /// <param name="validateEmail"></param>
        /// <returns> Email User </returns>
        [HttpGet]
        public async Task<IActionResult> ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Fields cannot be empty");

            }
            var response = await _userApplication.GetEmailAsync(email);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        /// <summary>
        /// Validate Verification Code
        /// </summary>
        /// <param name="validateCodeVerificationDTO"></param>
        /// <returns> Verification Code </returns>
        [HttpPost]
        public IActionResult ForgetPasswordVerificationCode([FromBody] ValidateVerificationCodeDTO validateCodeVerificationDTO)
        {
            var response = _userApplication.ForgetPasswordVerificationCode(validateCodeVerificationDTO);

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {

                    return Ok(response.Message);
                }
                else
                {
                    return NotFound(response.Message);
                }
            }

            return BadRequest(response.Message);
        }


        /// <summary>
        /// Update User Change Password
        /// </summary>
        /// <param name="changeUserPasswordDTO"></param>
        /// <returns> Password </returns>
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordDTO changeUserPasswordDTO)
        {
            if (changeUserPasswordDTO == null)
            {
                return BadRequest("Fields cannot be empty");

            }

            var response = await _userApplication.UpdateUserPasswordAsync(changeUserPasswordDTO);

            if (response.IsSuccess)
            {

                var message = new Message(new string[] { $"{ changeUserPasswordDTO.Email }" }, "Bienvenido a Ofesauto", "<span><strong>Bienvenido al sitio cambio de contraseña de OFESAUTO.</strong><span></br></br><hr><p style='color:black;'text-align:center;'></br></br></br><div style='color:black;'text-align:center;'>Su contraseña fue cambiada exitosamente.</br></br></br></div></br></br> <a href=http://ofesauto.es/></a></br>&reg; 2021 Ofesauto. All right reserved.</p>", null);
                _emailSender.SendEmail(message);

                return Ok(response.Message);
            }
            else
            {
                //return BadRequest(response.Message);
                return BadRequest("Invalid Email. Please enter the Email correct!");
            }
        }



        #region [ CREATE TOKEN ]
        /// <summary>
        /// Method Create Token Of Authentication
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns> Token </returns>
        private string TokenCreation(Response<LoginResponseDTO> loginDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret.ToString());
            int expiryToken = 5;

            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.NameIdentifier, loginDto.Data.Email),
                    new Claim(ClaimTypes.Email, loginDto.Data.Email),
                    new Claim("Id", loginDto.Data.UserId.ToString()),
                    new Claim($"UserName", loginDto.Data.UserName),
                    new Claim($"UserLastName", loginDto.Data.LastName),
                    new Claim($"UserType", loginDto.Data.UserTypeDescription),
                    new Claim($"DocumentNumber", loginDto.Data.DocumentNumber),
                    new Claim($"UserTypeId", loginDto.Data.UserTypeId.ToString()),
                    new Claim($"DocumentTypeId", loginDto.Data.DocumentTypeId.ToString()),


                }),
                Expires = DateTime.UtcNow.AddDays(expiryToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokendescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        #endregion


        #region [ GENERATE RANDOM NUMBERS ]
        /// <summary>
        /// Generate Numbers Randoms 5 Digits
        /// </summary>
        /// <param name="createRandomNumbers"></param>
        /// <returns> 5 Digits </returns>
        private static string CreateRandomNumbers(Response<ValidateEmailUserDTO> createRandomNumbers)
        {
            string numbers = "123456789";
            int len = numbers.Length;
            string otp = string.Empty;

            // How many digits otp you want mention below
            int optdigit = 5;
            string finalDigit;
            int getIndex;

            for (int i = 0; i < optdigit; i++)
            {
                do
                {
                    getIndex = new Random().Next(0, len);
                    finalDigit = numbers.ToCharArray()[getIndex].ToString();

                }
                while (otp.IndexOf(finalDigit) != -1);

                otp += finalDigit;
            }

            return otp;
        }
        #endregion
    }
}
