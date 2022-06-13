using Devyt.Infrastructure.Common;
using Devyt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Devyt.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DevytEntities _context = new DevytEntities();

        //get all objects
        public async Task<ResultModelList<T>> GetAll()
        {
            try
            {
                List<T> val = await _context.Set<T>().ToListAsync();
                return new ResultModelList<T>(true, "", val);
            }
            catch (Exception ex)
            {
                return new ResultModelList<T>(false, ex.Message, null);
            }
        }

        //get object by id
        public ResultModel<T> GetById(int id)
        {
            try
            {
                return new ResultModel<T>(true, "",  _context.Set<T>().Find(id));
            }
            catch (Exception ex)
            {
                return new ResultModel<T>(false, ex.Message, null);
            }
        }

        //get object by predicate
        public async Task<ResultModel<T>> GetPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                T res = await _context.Set<T>().FirstOrDefaultAsync(predicate);
                return new ResultModel<T>(true, "", res);
            }
            catch (Exception ex)
            {
                return new ResultModel<T>(false, ex.Message, null);
            }
        }

        //delete object
        public virtual async Task<ResultModel<T>> Delete(int id)
        {
            try
            {
                T val = await _context.Set<T>().FindAsync(id);
                _context.Set<T>().Remove(val);
                await _context.SaveChangesAsync();
                return new ResultModel<T>(true, "", null);
            }
            catch (Exception ex)
            {
                return new ResultModel<T>(false, ex.Message, null);
            }
        }

        //add object
        public virtual async Task<ResultModel<T>> Add(T entity)
        {
            T result = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return new ResultModel<T>(true, "", result);
        }

        //update object
        public virtual async Task<ResultModel<T>> Update(T entity)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new ResultModel<T>(true, "", entity);
            }
            catch (Exception ex)
            {
                return new ResultModel<T>(false, ex.Message, null);
            }
        }
    }
}