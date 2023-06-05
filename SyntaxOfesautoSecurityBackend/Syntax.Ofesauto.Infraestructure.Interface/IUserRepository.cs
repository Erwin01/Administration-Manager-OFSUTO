using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Infraestructure.Interface
{

    /// <summary>
    /// Method that allows you to perform the CRUD
    /// </summary>
    /// 
    #region [ IUSER REPOSITORY ]
    public interface IUserRepository
    {


        #region [ ASYNCHRONOUS METHODS ]

        #region [ USER METHODS ]
        Task<bool> InsertAsync(UserDTO user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(string userId);
        Task<User> GetByIdAsync(string userId);
        Task<IEnumerable<User>> GetAllAsync();
        #endregion


        #region [ DOCUMENT TYPE ]
        Task<IEnumerable<DocumentType>> GetAllDocumentTypeAsync();
        #endregion


        #region [ COUNTRY METHODS ]
        Task<IEnumerable<Country>> GetAllCountryAsync();
        Task<IEnumerable<CountryByRegion>> GetCountryByRegionIdAsync(string countryByRegionId);
        Task<IEnumerable<PhoneCodeByCountry>> GetAllPhoneCodeByCountryIdAsync();
        #endregion


        #region [ REGION METHODS ]
        Task<IEnumerable<Region>> GetAllRegionAsync();
        Task<Region> GetRegionByIdAsync(string regionId);
        #endregion


        #region [ CITY METHODS ]
        Task<IEnumerable<City>> GetAllCityAsync();
        Task<City> GetCityByIdAsync(string cityId);
        Task<IEnumerable<CityByRegionByCountry>> GetCityByRegionByCountryAsync(string countryId, string regionId);

        #endregion


        #region [ AUTHENTICATE METHODS ]
        LoginResponseDTO Authenticate(LoginDTO loginDTO);
        #endregion


        #region [ FORGET PASSWORD METHOD ]
        ValidateEmailUserDTO ForgetPassword(ValidateEmailUserDTO validateEmail);
        Task<ValidateEmail> GetEmailAsync(string email);
        ValidateVerificationCodeDTO ForgetPasswordVerificationCode(ValidateVerificationCodeDTO validateCodeVerificationDTO);

        Task<bool> UpdateUserPasswordAsync(ChangeUserPassword changeUserPassword);
        #endregion

        #endregion

    }
    #endregion

}
