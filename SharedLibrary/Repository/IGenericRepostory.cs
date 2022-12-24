using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharedLibrary.Repository
{
    public interface IGenericRepository
    {
        DbSet<T> All<T>() where T : class;
        void Remove<T>(int id) where T : class;
        void Remove<T>(T entity) where T : class;
        void RemoveRange<T>(IList<T> entities) where T : class;
        T Find<T>(int id) where T : class;
        IQueryable<T> Find<T>(Expression<System.Func<T, bool>> predicate) where T : class;
        T FindExpression<T>(Expression<System.Func<T, bool>> predicate) where T : class;
        void Add<T>(T entity) where T : class;
        void AddRange<T>(List<T> entities) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        void SaveChanges();
    }
}
