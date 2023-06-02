using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Application.Interface
{
    #region [ IUSER APPLICATION ]
    public interface IUserApplication
    {


        #region [ ASYNCHRONOUS METHODS ]


        #region [ USER METHODS ]
        Task<Response<bool>> InsertAsync(UserDTO user);
        Task<Response<bool>> UpdateAsync(UserDTO user);
        Task<Response<bool>> DeleteAsync(string userId);
        Task<Response<UserDTO>> GetByIdAsync(string userId);
        Task<Response<IEnumerable<UserDTO>>> GetAllAsync();
        #endregion


        #region [ DOCUMENT TYPE ]
        Task<Response<IEnumerable<DocumentTypeDTO>>> GetAllDocumentTypeAsync();
        #endregion


        #region [ COUNTRY METHODS ]
        Task<Response<IEnumerable<CountryDTO>>> GetAllCountryAsync();
        Task<Response<IEnumerable<CountryByRegionDTO>>> GetCountryByRegionIdAsync(string countryByRegionId);
        Task<Response<IEnumerable<PhoneCodeByCountryDTO>>> GetAllPhoneCodeByCountryIdAsync();
        #endregion


        #region [ REGION METHODS ]
        Task<Response<IEnumerable<RegionDTO>>> GetAllRegionAsync();
        Task<Response<RegionDTO>> GetRegionByIdAsync(string regionId);
        #endregion


        #region [ CITY METHODS ]
        Task<Response<IEnumerable<CityDTO>>> GetAllCityAsync();
        Task<Response<CityDTO>> GetCityByIdAsync(string cityId);
        Task<Response<IEnumerable<CityByRegionByCountryDTO>>> GetCityByRegionByCountryAsync(string countryId, string regionId);
        #endregion


        #region [ AUTHENTICATE METHODS ]
        Response<LoginResponseDTO> Authenticate(LoginDTO loginDTO);
        #endregion


        #region [ FORGET PASSWORD METHODS ]
        Response<ValidateEmailUserDTO> ForgetPassword(ValidateEmailUserDTO validateUserEmailDTO);
        Task<Response<ValidateEmailDTO>> GetEmailAsync(string email);
        Response<ValidateVerificationCodeDTO> ForgetPasswordVerificationCode(ValidateVerificationCodeDTO validateCodeVerificationDTO);
        Task<Response<bool>> UpdateUserPasswordAsync(ChangeUserPasswordDTO changeUserPasswordDTO);
        #endregion

    }
    #endregion

}
#endregion
