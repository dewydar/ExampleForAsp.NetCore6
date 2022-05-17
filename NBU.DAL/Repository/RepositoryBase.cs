using Microsoft.EntityFrameworkCore;
using NBU.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected SqlDbContext _db;
        protected DbSet<T> _dbSet;
        public RepositoryBase() : this(new SqlDbContext()) { }
        public RepositoryBase(SqlDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public DbContext db
        {
            get { return _db; }
        }
        public async Task<T> GetOne(Expression<Func<T, bool>> filter = null, List<string>? includes = null)
        {
            try
            {
                return await _db.Set<T>().WithIncludes(includes).FirstOrDefaultAsync(filter);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null, List<string>? includes = null)
        {
            try
            {
                if(filter!=null)
                    return await _db.Set<T>().AsNoTracking().WithIncludes(includes).Where(filter).ToListAsync();
                else
                    return await _db.Set<T>().AsNoTracking().WithIncludes(includes).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<T> Add(T entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<T>> AddRange(List<T> entity)
        {
            try
            {
                await _db.AddRangeAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<int> Delete(T entity)
        {
            try
            {
                _db.Remove(entity);
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<int> DeleteRange(List<T> entity)
        {
            try
            {
                _db.Remove(entity);
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<T> Update(T entity)
        {
            try
            {
                _db.Update(entity);
                await _db.SaveChangesAsync();
                return entity as T;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<List<T>> UpdateRange(List<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    _db.Update(entity);
                }
                await _db.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
    public static class LinqExtensions
    {
        public static IQueryable<T> WithIncludes<T>(this IQueryable<T> source, List<string> associations) where T : class
        {
            var query = (IQueryable<T>)source;
            if (associations != null)
                foreach (var assoc in associations)
                {
                    query = query.Include(assoc);
                }
            return query;
        }
    }
}
