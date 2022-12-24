using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext, new()
    {
        private readonly T _context;

        public UnitOfWork()
        {
            _context = new T();
        }

        public UnitOfWork(T Context)
        {
            _context = Context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }


        public T Context
        {
            get
            {
                return _context;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }

}
