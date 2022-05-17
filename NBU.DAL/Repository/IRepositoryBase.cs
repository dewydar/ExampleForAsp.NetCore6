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
    public interface IRepositoryBase<T> where T : class
    {
        DbContext db { get; }
        Task<T> GetOne(Expression<Func<T, bool>> filter = null, List<string>? includes = null);
        //Task<T> Get();
        //Task<T> GetById(int Id);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null, List<string>? includes=null);
       // Task<List<T>> GetListWithFilter(Expression<Func<T, bool>> filter = null, List<string>? includes=null);
        Task<T> Add(T entity);
        Task<List<T>> AddRange(List<T> entity);
        Task<T> Update(T entity);
        Task<List<T>> UpdateRange(List<T> entity);
        Task<int> Delete(T entity);
        Task<int> DeleteRange(List<T> entity);
    }
}
