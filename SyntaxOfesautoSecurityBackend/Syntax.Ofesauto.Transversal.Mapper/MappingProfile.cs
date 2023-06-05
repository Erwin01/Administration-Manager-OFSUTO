using AutoMapper;
using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Domain.Entity;


namespace Syntax.Ofesauto.Security.Transversal.Mapper
{

    /// <summary>
    /// Method that allows mapping automatically between data objects and business entities.
    /// </summary>
    /// 
    public class MappingProfile : Profile
    {

        #region [ CONSTRUCTOR ]
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<CountryByRegion, CountryByRegionDTO>().ReverseMap();
            CreateMap<CityByRegionByCountry, CityByRegionByCountryDTO>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeDTO>().ReverseMap();
            CreateMap<ValidateEmailUser, ValidateEmailUserDTO>().ReverseMap();
            CreateMap<ValidateEmail, ValidateEmailDTO>().ReverseMap();
            CreateMap<ValidateVerificationCode, ValidateVerificationCodeDTO>().ReverseMap();
            CreateMap<UserInsertVerificationCode, UserInsertVerificationCodeDTO>().ReverseMap();
            CreateMap<ChangeUserPassword, ChangeUserPasswordDTO>().ReverseMap();
            CreateMap<PhoneCodeByCountry, PhoneCodeByCountryDTO>().ReverseMap();


            CreateMap<User, UserDTO>().ReverseMap()
                .ForMember(destination => destination.UserId, source => source.MapFrom(src => src.UserId))
                .ForMember(destination => destination.UserTypeId, source => source.MapFrom(src => src.UserTypeId))
                .ForMember(destination => destination.UserName, source => source.MapFrom(src => src.UserName))
                .ForMember(destination => destination.LastName, source => source.MapFrom(src => src.LastName))
                .ForMember(destination => destination.DocumentTypeId, source => source.MapFrom(src => src.DocumentTypeId))
                .ForMember(destination => destination.UserIdNumber, source => source.MapFrom(src => src.UserIdNumber))
                .ForMember(destination => destination.UserAddress, source => source.MapFrom(src => src.UserAddress))
                .ForMember(destination => destination.CountryId, source => source.MapFrom(src => src.CountryId))
                .ForMember(destination => destination.RegionId, source => source.MapFrom(src => src.RegionId))
                .ForMember(destination => destination.CityId, source => source.MapFrom(src => src.CityId))
                .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
                .ForMember(destination => destination.PhoneCodeId, source => source.MapFrom(src => src.PhoneCodeId))
                .ForMember(destination => destination.PhoneNumber, source => source.MapFrom(src => src.PhoneNumber))
                .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Email))
                .ForMember(destination => destination.Password, source => source.MapFrom(src => src.Password))
                .ForMember(destination => destination.Photo, source => source.MapFrom(src => src.Photo))
                .ForMember(destination => destination.CreatedDate, source => source.MapFrom(src => src.CreatedDate))
                .ForMember(destination => destination.UpdatedDate, source => source.MapFrom(src => src.UpdatedDate));


            CreateMap<Login, LoginDTO>().ReverseMap()
               .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Email))
               .ForMember(destination => destination.Password, source => source.MapFrom(src => src.Password));


            CreateMap<Country, CountryDTO>().ReverseMap()
               .ForMember(destination => destination.CountryId, source => source.MapFrom(src => src.CountryId))
               .ForMember(destination => destination.CountryName, source => source.MapFrom(src => src.CountryName));


            CreateMap<Region, RegionDTO>().ReverseMap()
               .ForMember(destination => destination.RegionId, source => source.MapFrom(src => src.RegionId))
               .ForMember(destination => destination.RegionName, source => source.MapFrom(src => src.RegionName));


            CreateMap<City, CityDTO>().ReverseMap()
               .ForMember(destination => destination.CityId, source => source.MapFrom(src => src.CityId))
               .ForMember(destination => destination.CityName, source => source.MapFrom(src => src.CityName));


            CreateMap<CountryByRegion, CountryByRegion>().ReverseMap()
               .ForMember(destination => destination.CountryId, source => source.MapFrom(src => src.CountryId))
               .ForMember(destination => destination.CountryName, source => source.MapFrom(src => src.CountryName))
               .ForMember(destination => destination.PhoneCodeId, source => source.MapFrom(src => src.PhoneCodeId))
               .ForMember(destination => destination.RegionId, source => source.MapFrom(src => src.RegionId))
               .ForMember(destination => destination.RegionName, source => source.MapFrom(src => src.RegionName));


            CreateMap<CityByRegionByCountry, CityByRegionByCountryDTO>().ReverseMap()
               .ForMember(destination => destination.CityId, source => source.MapFrom(src => src.CityId))
               .ForMember(destination => destination.CityName, source => source.MapFrom(src => src.CityName));


            CreateMap<DocumentType, DocumentTypeDTO>().ReverseMap()
               .ForMember(destination => destination.DocumentTypeId, source => source.MapFrom(src => src.DocumentTypeId))
               .ForMember(destination => destination.DocumentTypeName, source => source.MapFrom(src => src.DocumentTypeName));


            CreateMap<ValidateEmailUser, ValidateEmailUserDTO>().ReverseMap()
               .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Email));


            CreateMap<ValidateEmail, ValidateEmailDTO>().ReverseMap()
               .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Email));


            CreateMap<ValidateVerificationCode, ValidateVerificationCodeDTO>().ReverseMap()
               .ForMember(destination => destination.CodeVerification, source => source.MapFrom(src => src.CodeVerification));


            CreateMap<UserInsertVerificationCode, UserInsertVerificationCodeDTO>().ReverseMap()
               .ForMember(destination => destination.UserId, source => source.MapFrom(src => src.UserId))
               .ForMember(destination => destination.VerificationCode, source => source.MapFrom(src => src.VerificationCode));


            CreateMap<ChangeUserPassword, ChangeUserPasswordDTO>().ReverseMap()
               .ForMember(destination => destination.Password, source => source.MapFrom(src => src.Password));


            CreateMap<PhoneCodeByCountry, PhoneCodeByCountryDTO>().ReverseMap()
               .ForMember(destination => destination.CountryId, source => source.MapFrom(src => src.CountryId))
               .ForMember(destination => destination.CountryName, source => source.MapFrom(src => src.CountryName))
               .ForMember(destination => destination.PhoneCodeId, source => source.MapFrom(src => src.PhoneCodeId));

        }
        #endregion

    }

}
