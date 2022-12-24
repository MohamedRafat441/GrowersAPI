using Microsoft.EntityFrameworkCore;
using SharedLibrary.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharedLibrary.Repository
{
    public class GenericRepository<C> : IGenericRepository where C : DbContext
    {
        //protected readonly C _context;
        protected readonly C _context;
        public GenericRepository(IUnitOfWork<C> unitOfWork)
        {
            _context = unitOfWork.Context;

        }

        public void SaveChanges()
        {
            _context.SaveChanges();

        }
        public async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            return true;

        }

        public DbSet<T> All<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Remove<T>(int id) where T : class
        {
            T entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public void RemoveRange<T>(IList<T> entities) where T : class
        {
            if (entities.Count > 0)
            {
                _context.Set<T>().RemoveRange(entities);
            }
        }

        public T Find<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange<T>(List<T> entities) where T : class
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Find<T>(Expression<System.Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public T FindExpression<T>(Expression<System.Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
    }

}
