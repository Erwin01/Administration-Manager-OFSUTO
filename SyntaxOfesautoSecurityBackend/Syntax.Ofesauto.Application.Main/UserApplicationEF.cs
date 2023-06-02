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
    public class UserApplicationEF : IUserApplicationEF
    {
        private readonly IUserDomainEF _repository;
        public UserApplicationEF(IUserDomainEF ctx)
        {
            _repository = ctx;
        }
        public async Task<Response<UserDTO>> Add(UserDTO obj)
        {
            try
            {
                var mapp = AutoMapp<UserDTO, User>.Convert(obj);
                mapp.Password = ConvertToEncrypt(obj.UserIdNumber);
                var add = await _repository.Add(mapp);
                obj.UserId = add.UserId;
                return Response<UserDTO>.Sucess(obj, "Success", true);
            }
            catch (Exception ex)
            {
                return Response<UserDTO>.Error(null, ex, ex.Message, false);
            }
        }

        public async Task<Response<bool>> Delete(int id)
        {
            try
            {
                var add = await _repository.GetById(id);
                if (add.UserId > 0)
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

        public async Task<Response<List<UserDTO>>> GetAll()
        {
            try
            {
                var ListData = await _repository.GetAll();
                var mapp = AutoMapp<User, UserDTO>.ConvertList2(ListData);
                return Response<List<UserDTO>>.Sucess(mapp, "Success", true);
            }
            catch (Exception ex)
            {
                return Response<List<UserDTO>>.Error(null, ex, ex.Message, false);
            }
        }

        public async Task<Response<UserDTO>> GetById(int id)
        {
            try
            {
                var ListData = await _repository.GetById(id);
                var Data = AutoMapp<User, UserDTO>.Convert(ListData);
                return Response<UserDTO>.Sucess(Data, "Success", true);
            }
            catch (Exception ex)
            {
                return Response<UserDTO>.Error(null, ex, ex.Message, false);
            }
        }

        public async Task<Response<UserDTO>> Update(UserDTO obj, int id)
        {
            try
            {
                var objEx =  await _repository.GetById(id); ;
                if (objEx!= null)
                {
                    obj.UpdatedDate = DateTime.UtcNow;
                    var mapp = AutoMapp<UserDTO, User>.Convert(obj);
                    mapp.Password = objEx.Password;
                    mapp.CreatedDate = objEx.CreatedDate;
                    var add = await _repository.Update(mapp, id);
                    return Response<UserDTO>.Sucess(obj, "Success", true);
                }
                return Response<UserDTO>.Error(obj, null, "No existe usuario", false);
            }
            catch (Exception ex)
            {
                return Response<UserDTO>.Error(null, ex, ex.Message, false);
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
