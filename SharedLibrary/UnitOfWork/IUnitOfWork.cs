using Microsoft.EntityFrameworkCore;
using System;

namespace SharedLibrary.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T : DbContext
    {
        int Save();
        T Context { get; }
    }
}
