using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalData.Services
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
        IQueryable<T> Get();
        Task<T> GetSingleAsync(int ID);
        IQueryable<T> SearchBy(Expression<Func<T, bool>> predicate);
        T First();
        T Single(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAllAsync();
        //Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] navigatrionPropertyPath);
        IQueryable<T> Include(Expression<Func<T, object>> set, Expression<Func<T, bool>> criteria);
    }
}