using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Infraestructure.Interface
{
   public interface IRepository<T> where T : class
    {
        Task<T> Add(T obj);
        Task<T> Update(T obj, int id);
        Task<bool> Delete(int id);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<List<T>> GetByParam(Func<T, bool> pre);
        Task<T> GetByParamFirst(Func<T, bool> pre);
        Task<List<T>> AddList(List<T> obj);
        void Save(T obj, int id);
    }
}
