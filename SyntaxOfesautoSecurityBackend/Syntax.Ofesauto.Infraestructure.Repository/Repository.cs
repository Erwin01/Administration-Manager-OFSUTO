using Microsoft.EntityFrameworkCore;
using Syntax.Ofesauto.Security.Infraestructure.Data;
using Syntax.Ofesauto.Security.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Infraestructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CustomDataContext _context;
        public Repository(CustomDataContext context)
        {
            this._context = context;
        }

        public async Task<T> Add(T obj)
        {
            _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();
            //_context.Dispose();
            return obj;
        }
        public async Task<List<T>> AddList(List<T> obj)
        {
            await _context.Set<T>().AddRangeAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> Delete(int id)
        {
            var result = false;
            var item = await GetById(id);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                await _context.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<List<T>> GetAll()
        {
            var item = _context.Set<T>();
            return await item.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return await _context.Set<T>().FindAsync(id);

        }
        public async Task<T> GetByParamFirst(Func<T, bool> pre)
        {
            var item = _context.Set<T>().Where(pre);
            return item.FirstOrDefault();

        }

        public async Task<List<T>> GetByParam(Func<T, bool> pre)
        {
            var item = _context.Set<T>().Where(pre);
            return item.ToList();

        }

        public async Task<T> GetByParamLast(Func<T, bool> pre)
        {

            var item = _context.Set<T>().Where(pre);
            return item.LastOrDefault();

        }
        public void Save(T obj, int id)
        {
            _context.SaveChanges();
        }

        public async Task<T> Update(T obj, int id)
        {
            var x = _context.Entry(obj);
            _context.Set<T>().Attach(obj);
            x.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;

        }


    }
}
