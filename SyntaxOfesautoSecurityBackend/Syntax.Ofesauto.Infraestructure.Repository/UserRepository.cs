using Dapper;
using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Domain.Entity;
using Syntax.Ofesauto.Security.Infraestructure.Interface;
using Syntax.Ofesauto.Security.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Infraestructure.Repository
{
    /// <summary>
    /// Method to access the database we use a Dapper micro ORM
    /// </summary>
    /// 
    #region [ USER REPOSITORY ]
    public class UserRepository : IUserRepository
    {

        /// <summary>
        /// Object allows accessing the properties of different projects and using the stored procedures
        /// </summary>
        private readonly IConnectionFactory _connectionFactory;
        public static string secretKey = "$%/&@D=<+ohr/fo%kdse/)!";


        #region [ CONSTRUCTOR ]
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public UserRepository()
        {
        }
        #endregion


        #region [ ASYNCHRONOUS METHODS ]

        #region [ USER METHODS ]
        public async Task<bool> InsertAsync(UserDTO user)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserInsert";
                var parameters = new DynamicParameters();

                parameters.Add("UserId", user.UserId);
                parameters.Add("UserTypeId", 4);
                parameters.Add("UserName", user.UserName);
                parameters.Add("LastName", user.LastName);
                parameters.Add("DocumentTypeId", user.DocumentTypeId);
                parameters.Add("UserIdNumber", user.UserIdNumber);
                parameters.Add("UserAddress", user.UserAddress);
                parameters.Add("CountryId", user.CountryId);
                parameters.Add("RegionId", user.RegionId);
                parameters.Add("CityId", user.CityId);
                parameters.Add("PostalCode", user.PostalCode);
                parameters.Add("PhoneCodeId", user.PhoneCodeId);
                parameters.Add("PhoneNumber", user.PhoneNumber);
                parameters.Add("Email", user.Email);
                parameters.Add("Password", ConvertToEncrypt(user.Password));
                parameters.Add("Photo", user.Photo);
                parameters.Add("CreatedDate", DateTime.Now);
                parameters.Add("UpdatedDate", DateTime.Now);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }


        public async Task<bool> UpdateAsync(User user)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("UserId", user.UserId);
                parameters.Add("UserTypeId", user.UserTypeId);
                parameters.Add("UserName", user.UserName);
                parameters.Add("LastName", user.LastName);
                parameters.Add("DocumentTypeId", user.DocumentTypeId);
                parameters.Add("UserIdNumber", user.UserIdNumber);
                parameters.Add("UserAddress", user.UserAddress);
                parameters.Add("CountryId", user.CountryId);
                parameters.Add("RegionId", user.RegionId);
                parameters.Add("CityId", user.CityId);
                parameters.Add("PostalCode", user.PostalCode);
                parameters.Add("PhoneCodeId", user.PhoneCodeId);
                parameters.Add("PhoneNumber", user.PhoneNumber);
                parameters.Add("Email", user.Email);
                parameters.Add("Password", ConvertToEncrypt(user.Password));
                parameters.Add("VerificationCode", user.VerificationCode);
                parameters.Add("Photo", user.Photo);
                parameters.Add("CreatedDate", user.CreatedDate);
                parameters.Add("UpdatedDate", user.UpdatedDate);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }


        public async Task<bool> DeleteAsync(string userId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserDelete";
                var parameters = new DynamicParameters();

                parameters.Add("OrganismId", userId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }


        public async Task<User> GetByIdAsync(string userId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserGetById";
                var parameters = new DynamicParameters();

                parameters.Add("UserId", userId);

                var user = await connection.QuerySingleAsync<User>(query, param: parameters, commandType: CommandType.StoredProcedure);


                return user;

            }
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UserGetAll";

                var users = await connection.QueryAsync<User>(query, commandType: CommandType.StoredProcedure);

                return users;

            }
        }
        #endregion



        #region [ DOCUMENT TYPE ]
        /// <summary>
        /// Get All Document Types
        /// </summary>
        /// <returns> Documents Types </returns>
        public async Task<IEnumerable<DocumentType>> GetAllDocumentTypeAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "GetAllDocumentType";

                var documentType = await connection.QueryAsync<DocumentType>(query, commandType: CommandType.StoredProcedure);

                return documentType;

            }
        }
        #endregion



        #region [ COUNTRY METHODS ]
        /// <summary>
        /// Get All Countrys
        /// </summary>
        /// <returns> All Countrys </returns>
        public async Task<IEnumerable<Country>> GetAllCountryAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "GetAllCountry";

                var country = await connection.QueryAsync<Country>(query, commandType: CommandType.StoredProcedure);

                return country;

            }
        }


        /// <summary>
        ///  Get Country By Region
        /// </summary>
        /// <returns>All Countries With Regions</returns>
        public async Task<IEnumerable<CountryByRegion>> GetCountryByRegionIdAsync(string countryByRegionId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var storeProcedure = "GetCountryByRegion";

                var parameters = new DynamicParameters();

                parameters.Add("CountryId", countryByRegionId);

                var country = await connection.QueryAsync<CountryByRegion>(storeProcedure, param: parameters, commandType: CommandType.StoredProcedure);

                return country;

            }
        }

        /// <summary>
        /// Get All Phone Code by Country
        /// </summary>
        /// <returns>All Phone Codes With Country</returns>
        public async Task<IEnumerable<PhoneCodeByCountry>> GetAllPhoneCodeByCountryIdAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var storeProcedure = "GetAllPhoneCodeByCountry";

                var phoneCode = await connection.QueryAsync<PhoneCodeByCountry>(storeProcedure, commandType: CommandType.StoredProcedure);

                return phoneCode;

            }
        }
        #endregion



        #region [ REGION METHODS ]
        /// <summary>
        /// Get All Regions
        /// </summary>
        /// <returns> Get All Regions </returns>
        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "GetAllRegion";

                var regions = await connection.QueryAsync<Region>(query, commandType: CommandType.StoredProcedure);

                return regions;

            }
        }


        /// <summary>
        /// Get Region By Id
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns> Region By Id </returns>
        public async Task<Region> GetRegionByIdAsync(string regionId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "GetRegionById";
                var parameters = new DynamicParameters();

                parameters.Add("RegionId", regionId);

                var region = await connection.QuerySingleOrDefaultAsync<Region>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return region;

            }
        }
        #endregion



        #region [ CITY METHODS ]
        /// <summary>
        /// Get All Citys
        /// </summary>
        /// <returns> Citys </returns>
        public async Task<IEnumerable<City>> GetAllCityAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "GetAllCity";

                var city = await connection.QueryAsync<City>(query, commandType: CommandType.StoredProcedure);

                return city;

            }
        }


        /// <summary>
        /// Get City By Id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<City> GetCityByIdAsync(string cityId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "GetCityById";
                var parameters = new DynamicParameters();

                parameters.Add("CityId", cityId);

                var city = await connection.QuerySingleAsync<City>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return city;

            }
        }


        /// <summary>
        ///  Get City By Country
        /// </summary>
        /// <returns>All Cities with Countries</returns>
        public async Task<IEnumerable<CityByRegionByCountry>> GetCityByRegionByCountryAsync(string countryId, string regionId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var storeProcedure = "GetCityByRegionByCountry";

                var parameters = new DynamicParameters();

                parameters.Add("CountryId", countryId);
                parameters.Add("RegionId", regionId);

                var city = await connection.QueryAsync<CityByRegionByCountry>(storeProcedure, param: parameters, commandType: CommandType.StoredProcedure);

                return city;

            }
        }
        #endregion



        #region [ AUTHENTICATE METHODS ]
        /// <summary>
        /// Verificate Email and Password User
        /// </summary>
        /// <param name="login"></param>
        /// <returns> Email And Password User </returns>
        public LoginResponseDTO Authenticate(LoginDTO login)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "GetUserByUserAndPassword";
                var parameters = new DynamicParameters();

                parameters.Add("Email", login.Email);
                parameters.Add("Password", ConvertToEncrypt(login.Password));

                var user = connection.QuerySingle<LoginResponseDTO>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return user;

            }
        }
        #endregion



        #region [ FORGET PASSWORD METHOD ]
        /// <summary>
        /// Validate Email User If Exists Generate Verification And Insert Code In Database
        /// </summary>
        /// <param name="validateEmail"></param>
        /// <returns> Verification Code </returns>
        public ValidateEmailUserDTO ForgetPassword(ValidateEmailUserDTO validateEmail)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "ValidateUserEmail";
                var parameters = new DynamicParameters();
                parameters.Add("Email", validateEmail.Email);
                parameters.Add("VerificationCode", Convert.ToInt32(validateEmail.VerificationCode));

                var email = connection.QuerySingle<ValidateEmailUserDTO>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return email;

            }
        }


        /// <summary>
        /// Validate Only Email User
        /// </summary>
        /// <param name="email"></param>
        /// <returns> Email User </returns>
        public async Task<ValidateEmail> GetEmailAsync(string email)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "GetValidateEmail";
                var parameters = new DynamicParameters();

                parameters.Add("Email", email);

                var validateEmail = await connection.QuerySingleAsync<ValidateEmail>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return validateEmail;

            }
        }


        /// <summary>
        /// Validate Verification Code If Exists In The Database
        /// </summary>
        /// <param name="validateCodeVerificationDTO"></param>
        /// <returns> Verification Code </returns>
        public ValidateVerificationCodeDTO ForgetPasswordVerificationCode(ValidateVerificationCodeDTO validateCodeVerificationDTO)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "ValidateUserVerificationCode";
                var parameters = new DynamicParameters();

                parameters.Add("Email", validateCodeVerificationDTO.Email);
                parameters.Add("VerificationCode", validateCodeVerificationDTO.CodeVerification);

                var code = connection.QuerySingle<ValidateVerificationCodeDTO>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return code;
            }
        }


        /// <summary>
        /// Update Password of User
        /// </summary>
        /// <param name="changeUserPassword"></param>
        /// <returns> New Password </returns>
        public async Task<bool> UpdateUserPasswordAsync(ChangeUserPassword changeUserPassword)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UpdateChangeUserPassword";
                var parameters = new DynamicParameters();

                parameters.Add("Email", changeUserPassword.Email);
                parameters.Add("Password", ConvertToEncrypt(changeUserPassword.Password));

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;

            }
        }

        #endregion



        #region [ ENCRYPT PASSWORD ]
        /// <summary>
        /// Encrypt Password
        /// </summary>
        /// <param name="encryptPassword"></param>
        /// <returns> Password </returns>
        public static string ConvertToEncrypt(string encryptPassword)
        {

            if (string.IsNullOrEmpty(encryptPassword))
            {
                return "";
            }

            encryptPassword += secretKey;
            var passwordBytes = Encoding.UTF8.GetBytes(encryptPassword);

            return Convert.ToBase64String(passwordBytes);
        }
        #endregion

        #endregion

    }
}
#endregion


