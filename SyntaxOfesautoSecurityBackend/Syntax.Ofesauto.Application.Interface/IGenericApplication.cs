using Syntax.Ofesauto.Security.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Application.Interface
{
    public interface IGenericApplication<T> where T : class
    {
        Task<Response<T>> Add(T obj);
        Task<Response<T>> Update(T obj, int id);
        Task<Response<bool>> Delete(int id);
        Task<Response<List<T>>> GetAll();
        Task<Response<T>> GetById(int id);
    }
}
