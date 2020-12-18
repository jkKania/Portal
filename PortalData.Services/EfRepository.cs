using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalData.Models;

namespace PortalData.Services
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity<int>
    {
        protected DbSet<T> DbSet;
        protected DbContext Context;

        public EfRepository(DbContext context)
        {
            DbSet = context.Set<T>();
            Context = context;
        }

        public async Task AddAsync(T entity)
        {
            DbSet.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            return DbSet;
        }

        public async Task<T> GetSingleAsync(int ID)
        {
            return await DbSet.FindAsync(ID);
        }
        public T First()
        {
            return DbSet.First();
        }

        public IQueryable<T> SearchBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public T Single(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Single(predicate);
        }

        public IQueryable<T> GetAllAsync()
        {
            //async Task <IQueryable<T>>

            //params Expression<Func<T,object>>[] navigationPropertyPath

            //IQueryable<T> result = DbSet;
            //foreach (var set in navigationPropertyPath)
            //    result= result.Include(set);

            //return result;
            return DbSet;

            //return DbSet.Include(navigationPropertyPath[0]).Include(navigationPropertyPath[1]).Include(navigationPropertyPath[2]);
;        }

        public  IQueryable<T> Include(Expression<Func<T, object>> set, Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> result = DbSet;
            result = result.Include(set).Where(criteria);
            return result;
        }
    }
}