using AutoMapper;
using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Application.Interface;
using Syntax.Ofesauto.Security.Domain.Entity;
using Syntax.Ofesauto.Security.Domain.Interface;
using Syntax.Ofesauto.Security.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Application.Main
{

    /// <summary>
    /// Maps with DTO's and business entities and vice versa
    /// </summary>
    public class UserApplication : IUserApplication
    {
        /// <summary>
        /// Variables globlals
        /// </summary>
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UserApplication> _logger;

        /// <summary>
        /// This method allows to perform dependency injection
        /// </summary>
        /// <param name="customerDomain"></param>
        /// <param name="mapper"></param>
        public UserApplication(IUserDomain userDomain, IMapper imapper, IAppLogger<UserApplication> appLogger)
        {
            _userDomain = userDomain;
            _mapper = imapper;
            _logger = appLogger;
        }


        #region [ ASYNCHRONOUS METHODS ]


        #region [ USER METHODS ]
        public async Task<Response<bool>> InsertAsync(UserDTO userDto)
        {
            var response = new Response<bool>();

            try
            {
                var user = _mapper.Map<UserDTO>(userDto);
                response.Data = await _userDomain.InsertAsync(user);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful registration";
                    _logger.LogInformation("A new user was inserted!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }


        public async Task<Response<bool>> UpdateAsync(UserDTO userDto)
        {
            var response = new Response<bool>();

            try
            {
                var user = _mapper.Map<User>(userDto);
                response.Data = await _userDomain.UpdateAsync(user);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update";
                    _logger.LogInformation("A user was updated!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string userId)
        {
            var response = new Response<bool>();

            try
            {

                response.Data = await _userDomain.DeleteAsync(userId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful delete";
                    _logger.LogInformation("A user was deleted!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }

        public async Task<Response<UserDTO>> GetByIdAsync(string userId)
        {
            var response = new Response<UserDTO>();

            try
            {

                var user = await _userDomain.GetByIdAsync(userId);
                response.Data = _mapper.Map<UserDTO>(user);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("A user was consulted!" + $"{user.UserIdNumber}");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }


        public async Task<Response<IEnumerable<UserDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UserDTO>>();

            try
            {

                var users = await _userDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<UserDTO>>(users);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("All users were consulted!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }
        #endregion


        #region [ DOCUMENT TYPE ]
        public async Task<Response<IEnumerable<DocumentTypeDTO>>> GetAllDocumentTypeAsync()
        {
            var response = new Response<IEnumerable<DocumentTypeDTO>>();

            try
            {

                var users = await _userDomain.GetAllDocumentTypeAsync();
                response.Data = _mapper.Map<IEnumerable<DocumentTypeDTO>>(users);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("All document types were consulted!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }
        #endregion


        #region [ COUNTRY METHODS ]
        public async Task<Response<IEnumerable<CountryDTO>>> GetAllCountryAsync()
        {
            var response = new Response<IEnumerable<CountryDTO>>();

            try
            {

                var country = await _userDomain.GetAllCountryAsync();
                response.Data = _mapper.Map<IEnumerable<CountryDTO>>(country);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("All countries were consulted!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }

        /// <summary>
        ///  Get Country By Region Id
        /// </summary>
        /// <returns>All Country By Region</returns>
        public async Task<Response<IEnumerable<CountryByRegionDTO>>> GetCountryByRegionIdAsync(string countryByRegionId)
        {
            var response = new Response<IEnumerable<CountryByRegionDTO>>();

            try
            {

                var country = await _userDomain.GetCountryByRegionIdAsync(countryByRegionId);
                response.Data = _mapper.Map<IEnumerable<CountryByRegionDTO>>(country);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("Countries were consulted by region!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }


        public async Task<Response<IEnumerable<PhoneCodeByCountryDTO>>> GetAllPhoneCodeByCountryIdAsync()
        {
            var response = new Response<IEnumerable<PhoneCodeByCountryDTO>>();

            try
            {

                var phoneCode = await _userDomain.GetAllPhoneCodeByCountryIdAsync();
                response.Data = _mapper.Map<IEnumerable<PhoneCodeByCountryDTO>>(phoneCode);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("All phone codes were consulted!" + $"{phoneCode}");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }
        #endregion


        #region [ REGION METHODS ]
        public async Task<Response<IEnumerable<RegionDTO>>> GetAllRegionAsync()
        {
            var response = new Response<IEnumerable<RegionDTO>>();

            try
            {

                var region = await _userDomain.GetAllRegionAsync();
                response.Data = _mapper.Map<IEnumerable<RegionDTO>>(region);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("All regions were consulted!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }


        public async Task<Response<RegionDTO>> GetRegionByIdAsync(string regionId)
        {
            var response = new Response<RegionDTO>();

            try
            {

                var region = await _userDomain.GetRegionByIdAsync(regionId);
                response.Data = _mapper.Map<RegionDTO>(region);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("Region was consulted by Id!" + $"{region.RegionName}");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }
        #endregion


        #region [ CITY METHODS ]
        public async Task<Response<IEnumerable<CityDTO>>> GetAllCityAsync()
        {
            var response = new Response<IEnumerable<CityDTO>>();

            try
            {

                var city = await _userDomain.GetAllCityAsync();
                response.Data = _mapper.Map<IEnumerable<CityDTO>>(city);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("All cities were consulted!");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }


        public async Task<Response<CityDTO>> GetCityByIdAsync(string cityId)
        {
            var response = new Response<CityDTO>();

            try
            {

                var city = await _userDomain.GetCityByIdAsync(cityId);
                response.Data = _mapper.Map<CityDTO>(city);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("City was consulted by Id!" + $"{city.CityName}");

                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }

        /// <summary>
        ///  Get City by Country Id
        /// </summary>
        /// <returns>All Country with regions</returns>
        public async Task<Response<IEnumerable<CityByRegionByCountryDTO>>> GetCityByRegionByCountryAsync(string countryId, string regionId)
        {
            var response = new Response<IEnumerable<CityByRegionByCountryDTO>>();

            try
            {

                var city = await _userDomain.GetCityByRegionByCountryAsync(countryId, regionId);
                response.Data = _mapper.Map<IEnumerable<CityByRegionByCountryDTO>>(city);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInformation("City by country Id was consulted!");

                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }
        #endregion


        #region [ AUTHENTICATE METHODS ]
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Data user</returns>
        public Response<LoginResponseDTO> Authenticate(LoginDTO loginDTO)
        {
            var response = new Response<LoginResponseDTO>();

            if (string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
            {
                response.Message = "Fields cannot be empty";

                return response;
            }

            try
            {
                var user = _userDomain.Authenticate(loginDTO);

                response.Data = _mapper.Map<LoginResponseDTO>(user);
                response.IsSuccess = true;
                response.Message = "Succesfull authentication";
                _logger.LogInformation("The user has logged in!" + $"{loginDTO.Email}");

            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "User or password incorrect.";

            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }
        #endregion


        #region [ FORGET PASSWORD METHOD ]
        /// <summary>
        /// Validate if the user's email exists
        /// </summary>
        /// <param name="validateEmail"></param>
        /// <returns>Email user</returns>
        public Response<ValidateEmailUserDTO> ForgetPassword(ValidateEmailUserDTO validateEmail)
        {
            var response = new Response<ValidateEmailUserDTO>();

            if (string.IsNullOrEmpty(validateEmail.Email))
            {
                response.Message = "Field cannot be empty!";

                return response;
            }

            try
            {

                var email = _userDomain.ForgetPassword(validateEmail);

                if (string.IsNullOrEmpty(validateEmail.Email))
                {
                    response.Message = "Field cannot be empty!";
                }

                response.Data = _mapper.Map<ValidateEmailUserDTO>(validateEmail);
                response.IsSuccess = true;
                response.Message = "The user has validated his email and an email has been sent!" + $"{validateEmail.Email}";
                _logger.LogInformation("Succesful query!");

            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Invalid email. Please create account!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;

        }



        public async Task<Response<ValidateEmailDTO>> GetEmailAsync(string validateEmail)
        {
            var response = new Response<ValidateEmailDTO>();

            try
            {

                var email = await _userDomain.GetEmailAsync(validateEmail);
                response.Data = _mapper.Map<ValidateEmailDTO>(email);


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Email Successful query";
                    _logger.LogInformation("The user has validated his email!" + $"{email}");

                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                response.Message = "Invalid email. Please create account!";
            }

            return response;
        }


        public Response<ValidateVerificationCodeDTO> ForgetPasswordVerificationCode(ValidateVerificationCodeDTO validateCodeVerification)
        {
            var response = new Response<ValidateVerificationCodeDTO>();

            if (string.IsNullOrEmpty(validateCodeVerification.CodeVerification))
            {
                response.Message = "Field cannot be empty!";

                return response;
            }

            try
            {

                var email = _userDomain.ForgetPasswordVerificationCode(validateCodeVerification);

                if (string.IsNullOrEmpty(validateCodeVerification.CodeVerification))
                {
                    response.Message = "Field cannot be empty!";
                }

                response.Data = _mapper.Map<ValidateVerificationCodeDTO>(validateCodeVerification);
                response.IsSuccess = true;
                response.Message = "Valid code successfully";
                _logger.LogInformation("The user has validated the verification code!" + $"{validateCodeVerification.Email}");

            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Invalid Verification Code or Email incorrect. Please enter the correct code or Email correct!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;

        }


        public async Task<Response<bool>> UpdateUserPasswordAsync(ChangeUserPasswordDTO changeUserPasswordDTO)
        {
            var response = new Response<bool>();

            try
            {
                var changePassword = _mapper.Map<ChangeUserPassword>(changeUserPasswordDTO);
                response.Data = await _userDomain.UpdateUserPasswordAsync(changePassword);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update";
                    _logger.LogInformation("User has updated their password!" + $"{changePassword.Email}");
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }
        #endregion

        #endregion

    }

}
