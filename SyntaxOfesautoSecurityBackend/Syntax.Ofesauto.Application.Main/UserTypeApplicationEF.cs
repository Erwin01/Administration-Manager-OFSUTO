using Syntax.Ofesauto.Security.Application.DTO;
using Syntax.Ofesauto.Security.Application.Interface;
using Syntax.Ofesauto.Security.Domain.Entity;
using Syntax.Ofesauto.Security.Domain.Interface;
using Syntax.Ofesauto.Security.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Application.Main
{
    public class UserTypeApplicationEF : IUserTypeApplicationEF
    {
        private readonly IUserTypeDomainEF _repository;
        public UserTypeApplicationEF(IUserTypeDomainEF ctx)
        {
            _repository = ctx;
        }
        public async Task<Response<UserTypeDTO>> Add(UserTypeDTO obj)
        {
            try
            {
                var mapp = AutoMapp<UserTypeDTO, UserType>.Convert(obj);
                var add = await _repository.Add(mapp);
                obj.UserTypeId = add.UserTypeId;
                return Response<UserTypeDTO>.Sucess(obj, "Success", true);
            }
            catch (Exception ex)
            {
                return Response<UserTypeDTO>.Error(null, ex, ex.Message, false);
            }
        }

        public async Task<Response<bool>> Delete(int id)
        {
            try
            {
                var add = await _repository.GetById(id);
                if (add.UserTypeId > 0)
                {
                    await _repository.Delete(id);
                    return Response<bool>.Sucess(true, "Success", true);
                }
                else
                    return Response<bool>.Error(false, null, "Not found", false);
            }
            catch (Exception ex)
            {
                return Response<bool>.Error(false, ex, ex.Message, false);
            }
        }

        public async Task<Response<List<UserTypeDTO>>> GetAll()
        {
            try
            {
                var ListData = await _repository.GetAll();
                var mapp = AutoMapp<UserType, UserTypeDTO>.ConvertList2(ListData);
                return Response<List<UserTypeDTO>>.Sucess(mapp, "Success", true);
            }
            catch (Exception ex)
            {
                return Response<List<UserTypeDTO>>.Error(null, ex, ex.Message, false);
            }
        }

        public async Task<Response<UserTypeDTO>> GetById(int id)
        {
            try
            {
                var ListData = await _repository.GetById(id);
                var Data = AutoMapp<UserType, UserTypeDTO>.Convert(ListData);
                return Response<UserTypeDTO>.Sucess(Data, "Success", true);
            }
            catch (Exception ex)
            {
                return Response<UserTypeDTO>.Error(null, ex, ex.Message, false);
            }
        }

        public async Task<Response<UserTypeDTO>> Update(UserTypeDTO obj, int id)
        {
            try
            {
                var objEx =  await _repository.GetById(id); ;
                if (objEx!= null)
                {
                    obj.UpdatedDate = DateTime.UtcNow;
                    var mapp = AutoMapp<UserTypeDTO, UserType>.Convert(obj);
                    var add = await _repository.Update(mapp, id);
                    return Response<UserTypeDTO>.Sucess(obj, "Success", true);
                }
                return Response<UserTypeDTO>.Error(obj, null, "No existe usuario", false);
            }
            catch (Exception ex)
            {
                return Response<UserTypeDTO>.Error(null, ex, ex.Message, false);
            }
        }


        protected  string ConvertToEncrypt(string encryptPassword)
        {

            if (string.IsNullOrEmpty(encryptPassword))
            {
                return "";
            }
            var passwordBytes = Encoding.UTF8.GetBytes(encryptPassword);

            return Convert.ToBase64String(passwordBytes);
        }
    }
}
