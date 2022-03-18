using System;

namespace BlogSample.Core.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
